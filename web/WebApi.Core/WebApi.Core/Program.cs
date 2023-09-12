using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using log4net.Repository;
using log4net;
using WebApi.Common.App;
using WebApi.Extensions.ServiceExtensions;
using WebApi.Model.AutoMapper;
using WebApi.Model.Db;
using WebApi.Common.Helpers;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Repository.Mongo;
using WebApi.IRepository.Mongo;
using Autofac.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Aspose.Cells.Charts;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using WebApi.Jobs;

var builder = WebApplication.CreateBuilder(args);

//这里是替换容器的，微软默认的注入方式是DI，替换成autofac实例
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());
    })
    .ConfigureLogging(builder =>
    {
        // 1.过滤掉系统默认的一些日志
        builder.AddFilter("System", LogLevel.Error);
        builder.AddFilter("Microsoft", LogLevel.Error);

        // 2.也可以在appsettings.json中配置，LogLevel节点

        // 3.统一设置
        builder.SetMinimumLevel(LogLevel.Error);

        // 默认log4net.confg
        builder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));
    });

ILoggerRepository loggerRepository = LogManager.CreateRepository("NETCoreRepository");
Log4NetHelper.SetConfig(loggerRepository, "log4net.config");


//IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
//IConfigurationRoot root = configurationBuilder.Build();
builder.Services.AddSingleton(new Appsettings(builder.Configuration));


//添加jwt验证：
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,//是否验证Issuer
            ValidateAudience = true,//是否验证Audience
            ValidateLifetime = true,//是否验证失效时间
            ValidateIssuerSigningKey = true,//是否验证SecurityKey
            ValidAudience = "test",//Audience
            ValidIssuer = "test",//Issuer，这两项和前面签发jwt的设置一致
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Appsettings.GetApp(new string[] { "Authorization", "Jwt", "Key" })))//key
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IMapper, Mapper>();
#endregion

//builder.Services.AddScoped<IDatabaseContext, MongoDbContext>();
builder.Services.AddScoped<MongoDbContext>();
//Mongo Repository
builder.Services.AddScoped(typeof(IMongoBaseRepository<>), typeof(MongoBaseRepository<>));

//Aspose输出excel时需要带上
//builder.Services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; })
//        .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);

#region CORS
builder.Services.AddCors(options =>
{
    if (Appsettings.GetApp(new string[] { "Cors", "EnableAllIPs" }) == "0")
    {
        options.AddPolicy(Appsettings.GetApp(new string[] { "Cors", "PolicyName" }), policy =>
        {
            policy
            .WithOrigins(Appsettings.GetApp(new string[] { "Cors", "IPs" }).Split(','))
            .AllowAnyHeader()//Ensures that the policy allows any header.
            .AllowAnyMethod();
        });
    }
    else
    {
        //允许任意跨域请求
        options.AddPolicy(Appsettings.GetApp(new string[] { "Cors", "PolicyName" }),
            policy =>
            {
                policy
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
    }
});

//app.UseCors(Appsettings.GetApp(new string[] { "Cors", "PolicyName" }));
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();
//app.UseAuthentication()是启用身份验证中间件，它会验证请求中的身份信息，并将身份信息存储在HttpContext.User属性中。而app.UseAuthorization()是启用授权中间件，它会检查HttpContext.User中的身份信息是否有访问当前请求所需的权限。
//一定要先启用身份验证中间件再启用授权中间件，因为授权中间件需要使用身份验证中间件存储的身份信息来进行权限验证。如果没有启用身份验证中间件，授权中间件将无法获取到身份信息，从而无法进行权限验证。
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.RegisterJob();

//Task.Run(() =>
//{
//    _ = TestKafka.InitConsume();
//});

app.Run();
