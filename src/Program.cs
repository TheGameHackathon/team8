using thegame.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sokoban.Interfaces;
using Sokoban.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMvc();
builder.Services.AddSingleton<IRepository<Game>, GameInstanceRepository>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Use((context, next) =>
{
    context.Request.Path = "/index.html";
    return next();
});
app.UseStaticFiles();

app.Run();