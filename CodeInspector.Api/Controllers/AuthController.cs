using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CodeInspector.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("github/login")]
    public IActionResult Login()
    {
        var clientId =
            _configuration["GitHub:ClientId"];

        var callback =
            "http://localhost:5097/api/auth/github/callback";

        var url =
            $"https://github.com/login/oauth/authorize" +
            $"?client_id={clientId}" +
            $"&scope=read:user user:email" +
            $"&redirect_uri={Uri.EscapeDataString(callback)}";

        return Redirect(url);
    }

    [HttpGet("github/callback")]
    public async Task<IActionResult> Callback(string code)
    {
        var clientId = _configuration["GitHub:ClientId"];
        var clientSecret = _configuration["GitHub:ClientSecret"];

        using var http = new HttpClient();

        //-------------------------------------------------
        // Exchange code for access token
        //-------------------------------------------------

        var tokenResponse = await http.PostAsync(
            "https://github.com/login/oauth/access_token",
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
            { "client_id", clientId! },
            { "client_secret", clientSecret! },
            { "code", code }
            }));

        var tokenContent = await tokenResponse.Content.ReadAsStringAsync();

        var accessToken = tokenContent
            .Split('&')
            .First(x => x.StartsWith("access_token="))
            .Replace("access_token=", "");

        //-------------------------------------------------
        // Get GitHub User
        //-------------------------------------------------

        http.DefaultRequestHeaders.Clear();

        http.DefaultRequestHeaders.Add(
            "User-Agent",
            "CodeInspector");

        http.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer",
                accessToken);

        var userJson =
            await http.GetStringAsync(
                "https://api.github.com/user");

        return Content(userJson, "application/json");
    }
}