
using HelloWorld.Data;
using HelloWorld.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowConfiguredOrigins", policy =>
    {
        policy.WithOrigins(allowedOrigins!)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
    throw new ArgumentException("JWT Key is missing or too short (min 32 chars).");

if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
    throw new ArgumentException("Jwt:Issuer or Jwt:Audience is missing.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
                {
                    context.Token = authHeader.Substring("Bearer ".Length).Trim();
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NextJob API", Version = "v1" });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter 'Bearer' followed by your JWT token.",
        Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition("Bearer", jwtSecurityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddScoped<DataDapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IFreelancerProfileService, FreelancerProfileService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IJobInfoService, JobInfoService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IBudgetTypeService, BudgetTypeService>();
builder.Services.AddScoped<IEnglishLevelService, EnglishLevelService>();
builder.Services.AddScoped<IExperienceLevelService, ExperienceLevelService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IJobTypeService, JobTypeService>();
builder.Services.AddScoped<IPaymentStatusService, PaymentStatusService>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();
builder.Services.AddScoped<IContractStatusService, ContractStatusService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NextJob API v1");
        c.RoutePrefix = "swagger";
    });
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseWebSockets();
var connections = new List<WebSocket>();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var curName = context.Request.Query["name"];
        var ws = await context.WebSockets.AcceptWebSocketAsync();

        connections.Add(ws);
        await Broadcast($"{curName} joined the room");
        await Broadcast($"{connections.Count} users connected");

        await ReceiveMessage(ws, async (result, buffer) =>
        {
            if (result.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                await Broadcast($"{curName}: {message}");
            }
            else if (result.MessageType == WebSocketMessageType.Close || ws.State == WebSocketState.Aborted)
            {
                connections.Remove(ws);
                await Broadcast($"{curName} left the room");
                await Broadcast($"{connections.Count} users connected");
                await ws.CloseAsync(result.CloseStatus ?? WebSocketCloseStatus.NormalClosure, result.CloseStatusDescription, CancellationToken.None);
            }
        });
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

async Task ReceiveMessage(WebSocket socket, Func<WebSocketReceiveResult, byte[], Task> handleMessage)
{
    var buffer = new byte[1024 * 4];
    while (socket.State == WebSocketState.Open)
    {
        var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        await handleMessage(result, buffer);
    }
}

async Task Broadcast(string message)
{
    var bytes = Encoding.UTF8.GetBytes(message);
    foreach (var socket in connections)
    {
        if (socket.State == WebSocketState.Open)
        {
            await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
app.UseCors("AllowConfiguredOrigins");
app.MapControllers();
app.Run();
