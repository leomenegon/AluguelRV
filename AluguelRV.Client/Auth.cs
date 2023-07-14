using System.Net.Http.Headers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace AluguelRV.Client;

public class RVAuthProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;

    public RVAuthProvider(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage=localStorage;
        _http=http;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string token = await _localStorage.GetItemAsStringAsync("token");
        var identity = new ClaimsIdentity();

        _http.DefaultRequestHeaders.Authorization = null;

        try
        {
            if (!string.IsNullOrEmpty(token))
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token.Replace("\"", ""));
                identity = new ClaimsIdentity(jwt.Claims, "jwt", "username", "role");

                Console.WriteLine(identity.Name);

                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }
        }
        catch(Exception ex)
        {
            await _localStorage.RemoveItemAsync("token");
            Console.WriteLine(ex.ToString());
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
}