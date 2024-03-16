using Autofac.Extensions.DependencyInjection;
using Autofac;
using AutoMapper;
using StackExchange.Redis;
using WebServer.Common.Helpers;
using WebServer.Extensions.ServiceExtensions;
using WebServer.IService.Redis;
using WebServer.Model.AutoMapper;
using WebServer.Service.Redis;
using WebServer.IService.Mongo;
using WebServer.Service.Mongo;
using WebServer.IRepository.Mongo;
using WebServer.Repository.Mongo;
using WebServer.Filter;

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

        //// 默认log4net.confg
        //builder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));
    });


builder.Services.AddSingleton(new AppSettingHelper(builder.Configuration));

// Add services to the container.
builder.Services.AddControllers();
//全局注册
//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add(new LoggingActionFilter());
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




#region automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IMapper, Mapper>();
#endregion

//string myRedisConStr = AppSettingHelper.GetApp(new string[] { "Redis", "MyRedisConStr" });
//if (string.IsNullOrWhiteSpace(myRedisConStr))
//{
//    myRedisConStr = "124.220.210.116:6379";
//}
//string instanceName = AppSettingHelper.GetApp(new string[] { "Redis", "InstanceName" });
//if (string.IsNullOrWhiteSpace(myRedisConStr))
//{
//    instanceName = "web-server";
//}

//builder.Services.AddDistributedMemoryCache(options =>
//{
//    options.Configuration = myRedisConStr;
//    options.InstanceName = instanceName;
//});

//ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(myRedisConStr);
//IDatabase db = redis.GetDatabase();
//string value = "qwe123";
//db.StringSet("test_key", value);
//var res = db.StringGet("test_key").ToString();
//Console.WriteLine(res);
//var mykeyValue = db.StringGet("meykey").ToString();
//Console.WriteLine($"{mykeyValue}");

builder.Services.AddSingleton<IRedisService, RedisServiceImpl>();

builder.Services.AddSingleton<LoginLogService>();

#region CORS
builder.Services.AddCors(options =>
{
    if (AppSettingHelper.GetApp(new string[] { "Cors", "EnableAllIPs" }) == "0")
    {
        options.AddPolicy(AppSettingHelper.GetApp(new string[] { "Cors", "PolicyName" }), policy =>
        {
            policy
            .WithOrigins(AppSettingHelper.GetApp(new string[] { "Cors", "IPs" }).Split(','))
            .AllowAnyHeader()//Ensures that the policy allows any header.
            .AllowAnyMethod();
        });
    }
    else
    {
        //允许任意跨域请求
        options.AddPolicy(AppSettingHelper.GetApp(new string[] { "Cors", "PolicyName" }),
            policy =>
            {
                policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
    }
});

#endregion



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
