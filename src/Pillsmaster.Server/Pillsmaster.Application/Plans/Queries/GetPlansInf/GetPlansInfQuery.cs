using MediatR;
using Pillsmaster.Application.ViewModels;

namespace Pillsmaster.Application.Plans.Queries.GetPlansInf;

public class GetPlansInfQuery : IRequest<IEnumerable<PlanInfoViewModel>>
{
    public Guid UserId { get; set; }
}