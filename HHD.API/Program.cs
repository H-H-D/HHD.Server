using HHD.API.Configurations;
using HHD.API.Middlewares;
using HHD.API.Models;
using HHD.Service.Helpers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();


//Configure api url name
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                        new ConfigurationApiUrlName()));
});

var app = builder.Build();

await app.ConfigureAsync();
await app.RunAsync();