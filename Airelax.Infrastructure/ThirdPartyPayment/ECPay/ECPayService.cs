using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Airelax.Infrastructure.Helpers;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Definitions;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Definitions.Options;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Request;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Response;
using Lazcat.Infrastructure.Common;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Airelax.Infrastructure.ThirdPartyPayment.ECPay
{
    public interface IECPayService
    {
        Task<TokenResponseData> GetToken();
        Task<TransactResponseData> CreateTransaction(string token);
    }
    
    public class ECPayService : IECPayService
    {
        private readonly HttpClient _client;
        private readonly IOptions<ECPaySetting> _options;

        public ECPayService(HttpClient client, IOptions<ECPaySetting> options)
        {
            _options = options;
            client.BaseAddress = new Uri(_options.Value.BaseUrl);
            _client = client;
        }

        public async Task<TokenResponseData> GetToken()
        {
            var tokenRequest = new Request.ECRequest
            {
                //todo 
                MerchantId = _options.Value.MerchantId,
                RqHeader = new ECRequestHeader() {TimeStamp = DateTimeOffset.Now.ToUnixTimeSeconds(), Revision = _options.Value.Revision},
                Data = CryptographyHelper.AesEncrypt(JsonConvert.SerializeObject(new TokenRequestData()
                {
                    MerchantId = _options.Value.MerchantId,
                    RememberCard = RememberCard.No,
                    PaymentUIType = PaymentUIType.PaymentMethodList,
                    ChoosePaymentList = string.Join(',', new[] {(int) ChoosePayment.CreditCardPayAllAtOnce}),
                    OrderInfo = new OrderInfo()
                    {
                        MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                        MerchantTradeNo = "Airelax123",
                        TotalAmount = 1000,
                        ReturnUrl = "https://localhost:5001/api/system/suc",
                        TradeDesc = "測試用交易",
                        ItemName = "商品1#商品2#商品3",
                    },
                    ConsumerInfo = new ConsumerInfo()
                    {
                        Phone = "886912345678",
                        Name = "金城武",
                        CountryCode = "158",
                        Email = "fuck123@gmail.com",
                        MerchantMemberId = "M123456"
                    },
                    CardInfo = new CardInfo() {OrderResultUrl = "https://localhost:5001/Swagger/index.html"}
                }), _options.Value.AesKey, _options.Value.AesIV, true),
            };
            var responseMessage = await  _client.PostAsJsonAsync(_options.Value.Apis.GetTokenByTrade.Url,tokenRequest);
            var tokenResponse = await responseMessage.Content.ReadFromJsonAsync<TokenResponse>();
            var tokenResponseData = JsonConvert.DeserializeObject<TokenResponseData>(CryptographyHelper.AesDecrypt(tokenResponse.Data, _options.Value.AesKey, _options.Value.AesIV, true));
            return tokenResponseData;
        }

        public async Task<TransactResponseData> CreateTransaction(string token)
        {
            var request = new ECRequest()
            {
                MerchantId = _options.Value.MerchantId, 
                RqHeader = new ECRequestHeader()
                {
                    TimeStamp = DateTimeOffset.Now.ToUnixTimeSeconds(), 
                    Revision = _options.Value.Revision
                },
            };

            var transactRequestData = new TransactRequestData()
            {
                MerchantId = _options.Value.MerchantId, 
                MerchantTradeNo = "Airelax123",
                PayToken = token,
            };

            request.Data = CryptographyHelper.AesEncrypt(JsonConvert.SerializeObject(transactRequestData), _options.Value.AesKey, _options.Value.AesIV, true);
            var responseMessage = await _client.PostAsJsonAsync(_options.Value.Apis.Transaction.Url, request);
            var response = await responseMessage.Content.ReadFromJsonAsync<TokenResponse>();
            var data =  JsonConvert.DeserializeObject<TransactResponseData>(CryptographyHelper.AesDecrypt(response.Data, _options.Value.AesKey, _options.Value.AesIV, true));
            return data;
        }
    }
}