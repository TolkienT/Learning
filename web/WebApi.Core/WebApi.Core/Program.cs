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

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IMapper, Mapper>();
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    if (Appsettings.GetApp(new string[] { "Cors", "EnableAllIPs" }) == "1")
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
#endregion
Console.WriteLine("Start");
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(Appsettings.GetApp(new string[] { "Cors", "PolicyName" }));

app.UseAuthorization();

app.MapControllers();

app.Run();
