using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using PhysicsEngine.Blazor;
using PhysicsEngine.Blazor.WebImplementations;
using PhysicsEngine.Common.Abstractions;
using PhysicsEngine.Common.Services;
using PhysicsEngine.WebImplementations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddSingleton<GameService>();
builder.Services.AddScoped<IGameControls, WebGameControls>();
builder.Services.AddScoped<IGraphicsRenderer>(services =>
{
    var jsRuntime = services.GetRequiredService<IJSRuntime>();
    // Note: You cannot directly obtain an ElementReference here as it's tied to a component's lifecycle
    // Consider passing IJSRuntime to your BlazorGraphicsRenderer and defer canvas initialization
    return new BlazorGraphicsRenderer(jsRuntime);
});

await builder.Build().RunAsync();
