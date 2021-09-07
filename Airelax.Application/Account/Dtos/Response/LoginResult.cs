namespace Airelax.Application.Account.Dtos.Response
{
    public class LoginResult
    {
        public string Token { get; set; }
        public AccountStatus Result { get; set; }
    }
}