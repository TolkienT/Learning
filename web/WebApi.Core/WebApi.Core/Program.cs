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

//�������滻�����ģ�΢��Ĭ�ϵ�ע�뷽ʽ��DI���滻��autofacʵ��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());
    })
    .ConfigureLogging(builder =>
    {
        // 1.���˵�ϵͳĬ�ϵ�һЩ��־
        builder.AddFilter("System", LogLevel.Error);
        builder.AddFilter("Microsoft", LogLevel.Error);

        // 2.Ҳ������appsettings.json�����ã�LogLevel�ڵ�

        // 3.ͳһ����
        builder.SetMinimumLevel(LogLevel.Error);

        // Ĭ��log4net.confg
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
        //���������������
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
