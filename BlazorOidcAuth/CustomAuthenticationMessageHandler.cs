using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;
namespace BlazorOidcAuth;

public class CustomAuthenticationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthenticationMessageHandler(IAccessTokenProvider provder, NavigationManager nav) : base(provder, nav)
    {
        ConfigureHandler(["https://engineering.snow.edu/auth/realms/SnowCollege/"]);
    }
}