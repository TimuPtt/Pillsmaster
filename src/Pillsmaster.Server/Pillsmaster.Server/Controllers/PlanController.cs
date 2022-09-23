using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Pillsmaster.API.Dtos;
using Pillsmaster.Application.Plans.Commands.CreatePlan;
using Pillsmaster.Application.Plans.Commands.DeletePlan;
using Pillsmaster.Application.Plans.Commands.UpdatePlan;
using Pillsmaster.Application.Plans.Commands.UpdatePlanAtTake;
using Pillsmaster.Application.Plans.Queries.GetPlan;
using Pillsmaster.Application.Plans.Queries.GetPlansInf;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pillsmaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanController : BaseController
    {
        public PlanController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        // GET api/<PlanController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanViewModel>> Get(Guid id,
            CancellationToken cancellationToken)
        {
            var query = new GetPlanQuery()
            {
                Id = id,
                UserId = UserId
            };
            var plan = await _mediator.Send(query, cancellationToken);
            return Ok(plan);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanInfoViewModel>>> GetPlansInf(CancellationToken cancellationToken)
        {
            var query = new GetPlansInfQuery()
            {
                UserId = UserId
            };
            var plan = await _mediator.Send(query, cancellationToken);
            return Ok(plan);
        }

        // POST api/<PlanController>
        [HttpPost]
        public async Task<ActionResult<Plan>> Post([FromBody] CreatePlanDto createPlanDto, 
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreatePlanCommand>(createPlanDto);
            command.UserId = UserId;
            var plan = await _mediator.Send(command, cancellationToken);
            return Ok(plan);
        }

        // PUT api/<PlanController>/5
        [HttpPut]
        public async Task<ActionResult<Plan>> Put([FromBody] UpdatePlanDto updatePlanDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdatePlanCommand>(updatePlanDto);
            command.UserId = UserId;
            var plan = await _mediator.Send(command, cancellationToken);
            return Ok(plan);
        }
        // PUT api/<PlanController>/5
        [HttpPut]
        [Route("AtTake")]
        public async Task<ActionResult<Plan>> PutAtTake([FromBody] UpdatePlanAtTakeDto updatePlanAtTakeDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdatePlanAtTakeCommand>(updatePlanAtTakeDto);
            command.UserId = UserId;
            var plan = await _mediator.Send(command, cancellationToken);
            return Ok(plan);
        }

        // DELETE api/<PlanController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Guid id, 
            CancellationToken cancellationToken)
        {
            var command = new DeletePlanCommand()
            {
                Id = id,
                UserId = UserId
            };
            var plan = await _mediator.Send(command, cancellationToken);
            return Ok(plan);
        }
    }
}
