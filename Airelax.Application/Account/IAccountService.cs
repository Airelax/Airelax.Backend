using System.Threading.Tasks;
using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Account.Dtos.Response;
using Airelax.Domain.Members;

namespace Airelax.Application.Account
{
    public interface IAccountService
    {
        Task<string> RegisterAccount(RegisterInput input);
        LoginResult LoginAccount(LoginInput input);
        Task<Member> GetMember();
        string GetAuthMemberId();
    }
}