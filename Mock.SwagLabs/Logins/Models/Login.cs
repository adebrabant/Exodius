using Mock.SwagLabs.Utilities;

namespace Mock.SwagLabs.Logins.Models;

public class Login : TestEntity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
