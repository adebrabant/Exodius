using Mock.SwagLabs.Configurations.Models;
using Mock.SwagLabs.Logins.Models;

namespace Mock.SwagLabs.Logins.Mappers;

public static class LoginExtension
{
    public static Login ToLogin(this User user)
    {
        return new Login
        {
            Username = user.UserName,
            Password = user.Password,
        };
    }
}
