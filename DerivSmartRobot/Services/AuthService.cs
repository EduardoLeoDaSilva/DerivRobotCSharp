using System.Net.Http.Headers;
using System.Text;
using DerivSmartRobot.Models.View;
using Newtonsoft.Json;

namespace DerivSmartRobot.Services
{
    public class AuthService : IAuthService
    {
        private readonly string BaseURL = "https://deriv-smart-auth-api.herokuapp.com/api/";
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
        }
        public async Task<User> Login(string email, string password)
        {

            var userToSend = new
            {
                email = email,
                password = password
            };

            var ttt = JsonConvert.SerializeObject(userToSend);
            var content = new StringContent(ttt, Encoding.UTF8, "application/json");

           var response = await _httpClient.PostAsync("user/login", content);

           if (response.IsSuccessStatusCode)
           {
               var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
               return user;
           }
           else
           {
               var tt = await response.Content.ReadAsStringAsync();

                return null;
           }
        }

        public async Task<string> UpdatePassword(string email, string password)
        {
            var userToSend = new
            {
                Email = email,
                Password = password
            };

            var content = new StringContent(JsonConvert.SerializeObject(userToSend), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("user/changePassowrd", content);

            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();
                return retorno;
            }
            else
            {
                return "Erro ao tentar atualizar senha";
            }
        }


        public async Task<string> SaveConfig(string email, string accountType, string apiToken)
        {
            var userToSend = new
            {
                Email = email,
                AccountType = Enum.Parse<AccountType>(accountType),
                ApiToken = apiToken
            };

            var content = new StringContent(JsonConvert.SerializeObject(userToSend), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("user/saveConfig", content);

            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();
                return retorno;
            }
            else
            {
                var tt = await response.Content.ReadAsStringAsync();
                return "Erro ao tentar salvar config";
            }
        }

        public async Task<User> GetOAuthData(string email, string userJwtToken)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {userJwtToken}");

            var response = await _httpClient.GetAsync($"user/OAuthData?email={email}");

            if (response.IsSuccessStatusCode)
            {
                var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                return user;
            }
            else
            {
                var tt = await response.Content.ReadAsStringAsync();

                return null;
            }
        }


    }
}
