using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using SSEA.Client.BL.Facades;
using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.Client.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddMudServices();

            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProviderService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<CodeListFacade>();
            builder.Services.AddScoped<MachineFacade>();

            await builder.Build().RunAsync();
        }
    }
}
