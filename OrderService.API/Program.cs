using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.SqlServer;
using Identity.Bugeto.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.RequestDecompression;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrderService.API;
using OrderService.API.ApiServices;
using OrderService.API.Filters;
using OrderService.API.HangFireServices;
using OrderService.API.Helpers.factory;
using OrderService.API.Helpers.FileStorage;
using OrderService.API.services;
using OrderService.Application;
using OrderService.Application.Contracts;
using OrderService.Application.Contracts.WepClientServices;
using OrderService.Domain.Common;
using OrderService.Domain.Entities;
using OrderService.Infrastructure;
using OrderService.Infrastructure.Persistance;
using OrderService.Infrastructure.WebClientApiservice;
using Serilog;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IOrderSQLService, OrderSQLService>();
builder.Services.AddScoped<SMSService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddControllers(optiopn =>
{
    var policy = new AuthorizationPolicyBuilder()
     .RequireClaim(ClaimTypes.NameIdentifier)
     .RequireClaim("hassport")
    .RequireAuthenticatedUser().Build();
    optiopn.Filters.Add(new AuthorizeFilter(policy));
    optiopn.Filters.Add(typeof(GlobalExeptionFilter));
    optiopn.Filters.Add(typeof(BadRequestFilter));
}).ConfigureApiBehaviorOptions(BadRequestBehavior.Parse);
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Logging.ClearProviders();
//server that expect gzipRequestDecompression
builder.Services.AddRequestDecompression();


//  Add response compression services
builder.Services.AddResponseCompression(options =>
{
    // Add Gzip and Brotli as supported providers
    options.Providers.Add<GzipCompressionProvider>();
    // Limit compression to specific MIME types (add application/json)
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/json" });
    // Optional: allow compression even for HTTPS responses
    options.EnableForHttps = true;
});

// 2️⃣ Configure compression levels
builder.Services.Configure<GzipCompressionProviderOptions>(opts =>
{
    opts.Level = CompressionLevel.Fastest; // Or Optimal
});

LogingConfig(builder);

CatchingConfig(builder);
ServiceInjection(builder);
SwaggerConfig(builder);
SecurityConfig(builder);
HangFireServices(builder);

var app = builder.Build();
app.UseRequestDecompression();
app.UseResponseCompression();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataBaseContext>();
    //var hangfireService = services.GetRequiredService<ReOccuringSendMessage>();
    //hangfireService.SendEmail();
    //await context.Database.MigrateAsync();
    await context.Database.MigrateAsync();
    await SeedData.SeedDataLast(context);
    await SeedData.SeedUserAppData(app)
    ;
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        // the second option is used in  "Student00" dropdown list
        //the first option is url and "StudentTest" "/swagger/StudentTest/swagger.json" 
        // is used in c.SwaggerDoc and    [ApiExplorerSettings(GroupName = "StudentTest")]
        //  c.SwaggerDoc("StudentTest", new OpenApiInfo { Title = "WebApi.Student.talajoor", Version = "Student", Description = " Api Student" });
        options.SwaggerEndpoint("/swagger/WebSite/swagger.json", "WebSite");
        options.SwaggerEndpoint("/swagger/AdminPannel/swagger.json", "AdminPannel");
        options.SwaggerEndpoint("/swagger/Product/swagger.json", "Product");
        options.SwaggerEndpoint("/swagger/StudentTest/swagger.json", "Student00");
  
    });


    app.UseHttpsRedirection();



    // SeedData.SeedAppData(app);
}
app.UseCors();
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

//app.UseHangfireDashboard();
app.Run();

static void SecurityConfig(WebApplicationBuilder builder)
{
    builder.Services.AddCors(option =>
    {
        var env = builder.Environment;
        if (env.IsDevelopment())
        {
            option.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
            });
        }
        else
        {
            string front = builder.Configuration["FrontEnd"].ToString();
            option.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(front).AllowAnyHeader().
                AllowAnyMethod()
                .WithExposedHeaders(new string[] { "rowcount" });
            });

        }


    });
    builder.Services.AddAuthorization(config =>
    {
        //user should have both claim to be authorized
        // config.AddPolicy("IsAdmin", policy => policy.RequireClaim("userRole", "admin"));
        // config.AddPolicy("IsCustomer", policy => policy.RequireClaim("customerRole", "customer"));
        config.AddPolicy("IsOperator", policy => policy.RequireRole(UserRole.OPERATOR));
    });
    builder.Services.AddScoped<ICurrentUser>(provider =>
    {
        var context = provider.GetService<IHttpContextAccessor>();
        var currentUser = new CurrentUser()
        {
            FullName = context?.HttpContext?.User.FindFirstValue("fullName") ?? "0",
            UserId = context?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0",

        };
        return currentUser;
    });
    builder.Services.AddScoped<IUserValidation, UserValidation>();
    builder.Services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<DataBaseContext>()
        .AddDefaultTokenProviders()
        .AddErrorDescriber<CustomIdentityError>();
    builder.Services.Configure<IdentityOptions>(options =>
    {
        // options.User.AllowedUserNameCharacters = "0123";

        //options.User.RequireUniqueEmail = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;//@#$%
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 3;
        options.Password.RequiredUniqueChars = 1;
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedAccount = false;

    });
    builder.Services.AddAuthentication(u =>
    {
        u.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;//HttpContext.getTokenAsync()
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecurityKey"])),
            ClockSkew = TimeSpan.Zero

        };
        options.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = context =>
            {
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                var validationService = context.HttpContext.RequestServices
                .GetRequiredService<IUserValidation>();

                return validationService.Excecut(context);
                // return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                return Task.CompletedTask;

            },
            OnMessageReceived = context =>
            {
                return Task.CompletedTask;
            },
            OnForbidden = context =>
            {
                return Task.CompletedTask;
            }



        };
    });
}

static void ServiceInjection(WebApplicationBuilder builder)
{
    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddInfrastructurService(builder.Configuration);
    builder.Services.AddSingleton<ReOccuringSendMessage>();
    builder.Services.AddScoped<IFileStorageService, AppLocalStorageService>();
    builder.Services.AddScoped<IExternalApiService, ExternalApiService>();
    builder.Services.AddScoped<IFactoryUpload>(provider =>
    {
        string ip = "hh";
        string path = "jyguy";
        string test = "uhyh";
        return new FactoryUpload(ip, path, test);

    });
}

static void HangFireServices(WebApplicationBuilder builder)
{
    //builder.Services.AddHangfire(configuration => configuration
    //       //.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    //       .UseSimpleAssemblyNameTypeSerializer()
    //       .UseRecommendedSerializerSettings()
    //       .UseSqlServerStorage(builder.Configuration["HangFireDb"], new SqlServerStorageOptions
    //       {
    //           CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
    //           SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
    //           QueuePollInterval = TimeSpan.Zero,
    //           UseRecommendedIsolationLevel = true,
    //           DisableGlobalLocks = true
    //       }));
    //builder.Services.AddHangfireServer();
    //builder.Services.AddHostedService<WorkerHangfire>();
}

static void SwaggerConfig(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Description =
                "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                "Example: \"Bearer 12345abcdef\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = JwtBearerDefaults.AuthenticationScheme
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
           new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {

        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "taladoc.xml"));
        c.SwaggerDoc("WebSite", new OpenApiInfo { Title = "WebApi.WebSite", Version = "WebSite", Description = "Website Api" });
        c.SwaggerDoc("AdminPannel", new OpenApiInfo { Title = "WebApi.panel.talajoor", Version = "AdminPannel", Description = " Api AdminPannel" });
        c.SwaggerDoc("Product", new OpenApiInfo { Title = "WebApi.Product.talajoor", Version = "Product", Description = " Api Product" });
        c.SwaggerDoc("StudentTest", new OpenApiInfo { Title = "WebApi.Student.talajoor", Version = "Student", Description = " Api Student" });
    });
}

static void CatchingConfig(WebApplicationBuilder builder)
{
    builder.Services.AddResponseCaching();
    builder.Services.AddMemoryCache();
}

static void LogingConfig(WebApplicationBuilder builder)
{
    builder.Logging.AddConsole();
    if (builder.Environment.IsDevelopment())
    {
        builder.Logging.SetMinimumLevel(LogLevel.Information);
    }
    else
    {
        builder.Logging.SetMinimumLevel(LogLevel.Error);

    }
}


//public class GzipDecompressionProvider : IDecompressionProvider
//{
//    public Stream GetDecompressionStream(Stream stream)
//    {
//        // Return a GZipStream that decompresses the incoming request body
//        return new GZipStream(stream, CompressionMode.Decompress, leaveOpen: false);
//    }
//}
