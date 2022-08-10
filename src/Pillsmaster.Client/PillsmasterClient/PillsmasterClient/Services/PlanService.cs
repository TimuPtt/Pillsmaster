using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.PlanModels;

namespace PillsmasterClient.Services
{
    public class PlanService : BaseService, IPlanService
    {
        public PlanService() : base(new HttpClient(GetInsecureHandler())) {}

        public async Task<Plan> GetPlanAsync(Guid planId)
        {
            var responce = await _httpClient.GetAsync($"/api/Plan/{planId}");

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                var plan = JsonConvert.DeserializeObject<Plan>(content);
                return plan;
            }

            return null;
        }

        public async Task<Plan> UpdatePlanAsync(Guid planId, PlanRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/api/Plan/{planId}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var updatedPlan = JsonConvert.DeserializeObject<Plan>(responseContent);
                return updatedPlan;
            }

            return null;
        }

        public Task DeletePlanAsync(Guid planId)
        {
            throw new NotImplementedException();
        }

        public async Task<Plan> PostPlanAsync(PlanRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/api/Plan", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var createdPlan = JsonConvert.DeserializeObject<Plan>(responseContent);
                return createdPlan;
            }

            return null;
        }
    }
}
