using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Newtonsoft.Json;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.Login;

namespace PillsmasterClient.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        static string BaseUrl = "https://192.168.100.7:7196";

        public async Task<string> Login(string email, string password)
        {
            var request = new LoginRequest
            {
                Email = email,
                Password = password
            };
            var json = JsonConvert.SerializeObject(request);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient(GetInsecureHandler())
            {
                BaseAddress = new Uri(BaseUrl)
            };
            var response = await client.PostAsync("/api/Authorization/login/", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                Application.Current.Properties["oauth_token"] = token;

                return "Успешно";
            }

            return null;
        }

        public async Task Register()
        {
            throw new NotImplementedException();
            //TODO: Implement registration
        }

        private HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}
