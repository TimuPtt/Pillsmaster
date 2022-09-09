using MediatR;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.UserMedicines.Queries.GetUserMedicines;

public class GetUserMedicinesQuery : IRequest<IEnumerable<UserMedicineViewModel>>
{
    public Guid UserId { get; set; }
}