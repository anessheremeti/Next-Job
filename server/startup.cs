using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HelloWorld.Data;
using HelloWorld.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

        services.AddSwaggerGen(c =>
        {
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

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
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
        services.AddScoped<IContractStatusService, ContractStatusService>();
        services.AddScoped<IEnglishLevelService, EnglishLevelService>();
        services.AddScoped<IExperienceLevelService, ExperienceLevelService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IJobTypeService, JobTypeService>();
        services.AddScoped<IPaymentStatusService, PaymentStatusService>();
        services.AddScoped<IUserTypeService, UserTypeService>();

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
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NextJob API v1");
                c.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseRouting();

        app.UseAuthentication(); 
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); 
        });
    }
}
