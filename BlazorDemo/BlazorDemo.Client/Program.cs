using BlazorDemo.Classes;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

/// Register IConfiguration to access configuration values directly
builder.Services.AddSingleton(builder.Configuration);

// Register WeatherDataReader with dependency injection
builder.Services.AddSingleton<WeatherDataReader>();


await builder.Build().RunAsync();
