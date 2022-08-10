using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.UserMedicineModels;

namespace PillsmasterClient.Services
{
    public class UserMedicineService : BaseService, IUserMedicineService
    {   
        public UserMedicineService() : base(new HttpClient(GetInsecureHandler())) { }
        public async Task<List<UserMedicine>> GetUserMedicinesAsync()
        {
            var response = await _httpClient.GetAsync("/api/UserMedicine");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var userMedicineList = JsonConvert.DeserializeObject<List<UserMedicine>>(content);

                foreach (var userMedicine in userMedicineList)
                {
                    if (userMedicine.Medicine.PharmaType != null &&
                        userMedicine.Medicine.PharmaType.ToLower() == "таблетки")
                    {
                        userMedicine.Medicine.Image = "icons_tabl.png";
                        continue;
                    }
                    if (userMedicine.Medicine.PharmaType != null &&
                        userMedicine.Medicine.PharmaType.ToLower() == "капсулы")
                    {
                        userMedicine.Medicine.Image = "icons_pill.png";
                        continue;
                    }

                    userMedicine.Medicine.Image = "Tabs_icon.png";
                }

                return userMedicineList;
            }

            return null;
        }

        public async Task DeleteUserMedicineAsync(Guid userMedicineId)
        {
            throw new NotImplementedException();
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
