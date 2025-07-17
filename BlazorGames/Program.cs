using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorGames
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            // Add game services
            builder.Services.AddScoped<GameLogic.Roygbiv.GameManager>();
            builder.Services.AddScoped<GameLogic.Roygbiv.UIManager>();
            builder.Services.AddScoped<GameLogic.BattleWordle.GameManager>();

            await builder.Build().RunAsync();
        }
    }
}
