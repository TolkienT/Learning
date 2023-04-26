using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using WebApi.Common.App;
using WebApi.Extensions.ServiceExtensions;
using WebApi.Model.AutoMapper;
using WebApi.Model.Db;

var builder = WebApplication.CreateBuilder(args);

//�������滻�����ģ�΢��Ĭ�ϵ�ע�뷽ʽ��DI���滻��autofacʵ��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());
    });
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
