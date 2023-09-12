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


//���jwt��֤��
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,//�Ƿ���֤Issuer
            ValidateAudience = true,//�Ƿ���֤Audience
            ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
            ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
            ValidAudience = "test",//Audience
            ValidIssuer = "test",//Issuer���������ǰ��ǩ��jwt������һ��
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

//Aspose���excelʱ��Ҫ����
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
//app.UseAuthentication()�����������֤�м����������֤�����е������Ϣ�����������Ϣ�洢��HttpContext.User�����С���app.UseAuthorization()��������Ȩ�м����������HttpContext.User�е������Ϣ�Ƿ��з��ʵ�ǰ���������Ȩ�ޡ�
//һ��Ҫ�����������֤�м����������Ȩ�м������Ϊ��Ȩ�м����Ҫʹ�������֤�м���洢�������Ϣ������Ȩ����֤�����û�����������֤�м������Ȩ�м�����޷���ȡ�������Ϣ���Ӷ��޷�����Ȩ����֤��
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.RegisterJob();

//Task.Run(() =>
//{
//    _ = TestKafka.InitConsume();
//});

app.Run();
