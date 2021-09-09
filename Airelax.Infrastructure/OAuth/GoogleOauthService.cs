using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax.Infrastructure.OAuth
{
    [DependencyInjection(typeof(IGoogleOauthService))]
    public class GoogleOauthService : IGoogleOauthService
    {
        private readonly HttpClient _httpClient;
        private const string GoogleOauthUrl = "https://oauth2.googleapis.com/tokeninfo";

        public GoogleOauthService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<GoogleUserProfile> GetGoogleUser(string token)
        {
            var googleUserProfile = await _httpClient.GetFromJsonAsync<GoogleUserProfile>($"{GoogleOauthUrl}?id_token={token}");
            Console.WriteLine(JsonSerializer.Serialize(googleUserProfile));
            return googleUserProfile;
        }
    }
}