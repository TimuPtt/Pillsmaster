using Newtonsoft.Json;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.PlanModels;
using PillsmasterClient.Models.UserMedicineModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PillsmasterClient.Services
{
    public class UserMedicineService : BaseService, IUserMedicineService
    {
        public UserMedicineService() : base(new HttpClient(GetInsecureHandler())) { }

        public async Task<UserMedicine> PostUserMedicine(UserMedecineRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/UserMedicine", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var createdUserMedicine = JsonConvert.DeserializeObject<UserMedicine>(responseContent);
                return createdUserMedicine;
            }

            return null;
        }
    }
}
