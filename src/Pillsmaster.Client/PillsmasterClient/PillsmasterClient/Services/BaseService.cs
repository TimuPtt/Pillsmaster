using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace PillsmasterClient.Services
{
    public abstract class BaseService
    {
        private readonly string _baseUrl = "https://192.168.1.70:7196";

        private protected readonly HttpClient _httpClient;

        protected BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
            (
                "bearer",
                Application.Current.Properties["oauth_token"].ToString()
            );
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public static HttpClientHandler GetInsecureHandler()
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
