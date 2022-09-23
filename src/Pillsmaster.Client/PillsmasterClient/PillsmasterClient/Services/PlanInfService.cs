using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.PlanModels;
using PillsmasterClient.Models.UserMedicineModels;

namespace PillsmasterClient.Services
{
    public class PlanInfService : BaseService, IPlanInfService
    {   
        public PlanInfService() : base(new HttpClient(GetInsecureHandler())) { }
        public async Task<List<PlanInf>> GetPlanInfAsync()
        {
            var response = await _httpClient.GetAsync("/api/Plan");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var planInfs = JsonConvert.DeserializeObject<List<PlanInf>>(content);

                foreach (var planInf in planInfs)
                {
                    switch (planInf.PharmaTypeId)
                    {
                        case 1:
                            planInf.Image = "icons_tabl.png";
                            continue;
                        case 2:
                            planInf.Image = "icons_pill.png";
                            continue;
                        default:
                            planInf.Image = "";
                            continue;
                    }
                }

                return planInfs;
            }

            return null;
        }

        public async Task<UserMedicine> PostUserMedicineAsync(UserMedecineRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/UserMedicine", content);

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
