using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.MedicineModels;

namespace PillsmasterClient.Services
{
    public class MedicineService : BaseService, IMedicineService
    {
        public MedicineService() : base(new HttpClient(GetInsecureHandler()))
        {

        }

        public async Task<Guid> PostMedicineAsync(MedicineRequest medicineRequest)
        {
            var json = JsonConvert.SerializeObject(medicineRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Medicine", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var medicineId = JsonConvert.DeserializeObject<Guid>(responseString);
                return medicineId;
            }

            return Guid.Empty;
        }
    }
}
