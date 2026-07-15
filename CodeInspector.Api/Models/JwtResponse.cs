namespace CodeInspector.Api.Models;

public class JwtResponse
{
    public string Token { get; set; } = "";

    public string UserName { get; set; } = "";

    public string Email { get; set; } = "";

    public string Avatar { get; set; } = "";
}