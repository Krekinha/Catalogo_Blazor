using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Catalogo_Blazor.Client.Auth
{
    public class DemoAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(4000);
            //indicamos se o usuário e seus claims estão autenticados
            var user = new ClaimsIdentity();

            return await Task.FromResult(new AuthenticationState(
                new ClaimsPrincipal(user)
                ));
        }
    }
}
