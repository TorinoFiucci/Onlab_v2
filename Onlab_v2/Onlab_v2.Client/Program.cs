using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Onlab.Api;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddHttpClient("MyApi", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddApiClientServices();

builder.Services.AddMudServices();

await builder.Build().RunAsync();

