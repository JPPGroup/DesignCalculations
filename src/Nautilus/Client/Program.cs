using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Jpp.DesignCalculations.Engine.Project;
using Nautilus.Client.Data;

namespace Nautilus.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage(config =>
            {
                config.JsonSerializerOptions.Converters.Add(new IProjectStandardConverter());
            });
            builder.Services.AddScoped<ITemplateSource, LocalTemplateSource>();
            builder.Services.AddScoped<IProjectSource, LocalProjectSource>();

            await builder.Build().RunAsync();
        }
    }
}
