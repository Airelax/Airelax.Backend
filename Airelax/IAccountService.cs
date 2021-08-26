using Airelax.Application.Account.Dtos.Request;

namespace Airelax
{
    public interface IAccountService
    {
        string RegisterAccount(RegisterInput input);
        string LoginAccount(LoginInput input);
    }
}