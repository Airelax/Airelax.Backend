using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Account.Dtos.Response;

namespace Airelax.Application.Account
{
    public interface IAccountService
    {
        string RegisterAccount(RegisterInput input);
        LoginResult LoginAccount(LoginInput input);
    }
}