using System;
using System.Net.Http;
using System.Threading.Tasks;
using ChartJs.Blazor.Samples.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ChartJs.Blazor.Samples.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ISamplesProvider, ApiSamplesProvider>();
            builder.Services.AddSingleton(new DualModeSerivce(serverMode: false));

            await builder.Build().RunAsync();
        }
    }
}
