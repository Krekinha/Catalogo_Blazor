using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
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
            var user = new ClaimsIdentity( new List<Claim>() {
                new Claim("chave", "valor"),
                new Claim(ClaimTypes.Name, "Dionison"),
                //new Claim(ClaimTypes.Role, "Admin")
            },"demo");

            return await Task.FromResult(new AuthenticationState(
                new ClaimsPrincipal(user)
                ));
        }
    }
}
