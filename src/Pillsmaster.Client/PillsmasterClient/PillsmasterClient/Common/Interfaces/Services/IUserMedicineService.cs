using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PillsmasterClient.Models.UserMedicineModels;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface IUserMedicineService
    {
        Task<List<UserMedicine>> GetUserMedicinesAsync();
        Task DeleteUserMedicineAsync(Guid userMedicineId);
        Task<UserMedicine> PostUserMedicineAsync(UserMedecineRequest request);
    }
}