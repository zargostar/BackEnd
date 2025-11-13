using Polly;
using Polly.Extensions.Http;
using SMSService.Api;
using SMSService.Api.ApiService;
using SMSService.Api.ApiService.ActorHandler;
using SMSService.Api.Dapper;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
//cliend compresion
// Add services to the container.
var configiuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SendSMSService>();
builder.Services.AddHttpClient<SuplierApiService>(config =>
{
    config.BaseAddress=new Uri(configiuration["apiUri"]);
});
builder.Services.AddHttpClient<ActorApiService>(config =>
{
    config.BaseAddress = new Uri(configiuration["apiUri"]);
}).AddHttpMessageHandler<ActorAuthHandler>()
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Brotli
}).AddPolicyHandler(PollyHelper.GetRetryPolicy())
.AddPolicyHandler(PollyHelper.GetCircuitBreakerPolicy());
builder.Services.AddScoped<ActorAuthHandler>();


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


