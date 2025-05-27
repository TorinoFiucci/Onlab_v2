using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Onlab.Api;
using MudBlazor;
using MudBlazor.Services;
using MudBlazor.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddHttpClient("MyApi", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddApiClientServices();

builder.Services.AddMudServices();

//// use this to add MudServices and the MudBlazor.Extensions
//builder.Services.AddMudServicesWithExtensions();

//// or this to add only the MudBlazor.Extensions but please ensure that this is added after mud servicdes are added. That means after `AddMudServices`
//builder.Services.AddMudExtensions();

await builder.Build().RunAsync();

