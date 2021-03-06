using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCartSample.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingCartSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IItemsService, ItemsService>();
            await builder.Build().RunAsync();
        }
    }
}
