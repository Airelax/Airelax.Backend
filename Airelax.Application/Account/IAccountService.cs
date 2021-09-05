using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Account.Dtos.Response;
using Airelax.Domain.Members;

namespace Airelax
{
    public interface IAccountService
    {
        string RegisterAccount(RegisterInput input);
        LoginResult LoginAccount(LoginInput input);


    }
}