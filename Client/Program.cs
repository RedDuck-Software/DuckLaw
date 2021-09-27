using Duck.Client.Service;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using MudBlazor.Services;

namespace Duck.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var apiUrlBase = builder.Configuration["ServerUrlBase"];

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrlBase) });

            Console.WriteLine("url base: " + apiUrlBase);

            builder.Services.AddScoped<IService, Servicess>();
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
    }
}
