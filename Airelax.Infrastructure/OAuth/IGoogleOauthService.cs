using System.Threading.Tasks;

namespace Airelax.Infrastructure.OAuth
{
    public interface IGoogleOauthService
    {
        Task<GoogleUserProfile> GetGoogleUser(string token);
    }
}