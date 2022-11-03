
using CacheProvider;
using Microsoft.Extensions.DependencyInjection;
using Web6.Common.Confs;
using Web6.Data;
using Web6.Plugin;
using Web6.Send;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.GetConnectionString("");
builder.Services.AddControllers();
builder.Services.AddDatabase();
builder.Services.AddHttpClients();
builder.Services.AddRedis();
builder.Services.AddScoped<IMessageProducer, MessageProducer>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsDev", builder =>
    {
        builder.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
    });

});


//var rabbitConf = builder.Configuration.GetRequiredSection("RabbitConf").Get<RabbitConf>();
//builder.Services.AddSingleton<RabbitConf>(builder.Configuration.GetRequiredSection("RabbitConf").Get<RabbitConf>());
builder.Services.Configure<RabbitConf>(builder.Configuration.GetRequiredSection("RabbitConf"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("corsDev");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

