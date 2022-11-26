
using AspNetCoreRateLimit;
using CacheProvider;
using System.Configuration;
using Web.Service.Concretes;
using Web6.Common.Confs;
using Web6.Data;
using Web6.Jwt;
using Web6.Plugin;
using Web6.Send;
using Web6.Service.Abstracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.GetConnectionString("");
builder.Services.AddControllers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddHttpClients();
builder.Services.AddRedis();
builder.Services.AddScoped<IMessageProducer, MessageProducer>();

builder.Services.AddScoped<IStudentService, StudentService>();


// needed to store rate limit counters and ip rules
builder.Services.AddMemoryCache();

//load general configuration from appsettings.json
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

//load ip rules from appsettings.json
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

// inject counter and rules stores
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

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

builder.Services.Configure<SaloonsConf>(builder.Configuration.GetRequiredSection("SaloonsConf"));

//builder.Services.AddScoped<IUserClaims, UserClaims>();
////jwt
builder.Services.Configure<JwtTokenConfiguration>(builder.Configuration.GetRequiredSection("Jwt"));
//builder.Services.AddJwtService();

var app = builder.Build();

app.UseIpRateLimiting();

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

