using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PillsmasterClient.Models.Login
{
    public class LoginRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
