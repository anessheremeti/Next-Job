using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
<<<<<<< HEAD
using HelloWorld.Data;
using HelloWorld.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
=======
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HelloWorld.Data;
using HelloWorld.Services;
using System;
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

public class Startup
{
    private readonly IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IConfiguration>(Configuration);

        var jwtKey = Configuration["Jwt:Key"];
        var jwtIssuer = Configuration["Jwt:Issuer"];
        var jwtAudience = Configuration["Jwt:Audience"];

        if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
            throw new ArgumentException("JWT Key must be at least 32 characters long.");

        if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
            throw new ArgumentException("Jwt:Issuer or Jwt:Audience is missing in configuration.");

        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
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
            });

        services.AddAuthorization();

        services.AddSwaggerGen(c =>
        {
<<<<<<< HEAD
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NextJob API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\nExample: \"Bearer eyJhbGciOiJIUzI1NiIs...\""
            });
=======
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "User API", Version = "v1" });

            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Enter 'Bearer' [space] and then your valid token in the text box below.\r\n\r\nExample: \"Bearer eyJhbGciOi...\"",
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            };

            c.AddSecurityDefinition("Bearer", jwtSecurityScheme);
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
<<<<<<< HEAD
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
=======
                    jwtSecurityScheme,
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
                    Array.Empty<string>()
                }
            });
        });

        // Register services and DataDapper
        services.AddScoped<DataDapper>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<IFreelancerProfileService, FreelancerProfileService>();
        services.AddScoped<IHistoryService, HistoryService>();
        services.AddScoped<IJobInfoService, JobInfoService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IBudgetTypeService, BudgetTypeService>();
<<<<<<< HEAD
        services.AddScoped<IContractStatusService, ContractStatusService>();
=======
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
        services.AddScoped<IEnglishLevelService, EnglishLevelService>();
        services.AddScoped<IExperienceLevelService, ExperienceLevelService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IJobTypeService, JobTypeService>();
        services.AddScoped<IPaymentStatusService, PaymentStatusService>();
        services.AddScoped<IUserTypeService, UserTypeService>();
<<<<<<< HEAD

        // JWT Configuration
        var jwtKey = Configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
        {
            throw new ArgumentException("JWT Key must be at least 32 characters long.");
        }

        services.AddAuthentication("JwtBearer")
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

        services.AddAuthorization();
        services.AddControllers(); 
=======
        services.AddScoped<IContractStatusService, ContractStatusService>();

        services.AddControllers();
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
<<<<<<< HEAD
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NextJob API v1");
                c.RoutePrefix = string.Empty;
=======
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API v1");
                c.RoutePrefix = "swagger"; 
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
            });
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication(); 
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); 
        });
    }
}
