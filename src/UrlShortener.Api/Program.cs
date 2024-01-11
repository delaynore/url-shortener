using UrlShortener.Api.Middleware;
using UrlShortener.Application.DependencyInjection;
using UrlShortener.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(365 + 365);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHsts();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();