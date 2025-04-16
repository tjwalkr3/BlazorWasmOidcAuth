using DerpRaven.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthenticationMessageHandler>();


builder.Services.AddHttpClient("testClient", opt => opt.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<CustomAuthenticationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("testClient"));

builder.Services.AddOidcAuthentication(opt =>
{
    opt.ProviderOptions.Authority = "https://engineering.snow.edu/auth/realms/SnowCollege/";
    opt.ProviderOptions.ClientId = "DerpClientSpring25";
    opt.ProviderOptions.ResponseType = "code";
    opt.ProviderOptions.DefaultScopes.Add("openid");
    opt.ProviderOptions.DefaultScopes.Add("profile");
});

await builder.Build().RunAsync();
