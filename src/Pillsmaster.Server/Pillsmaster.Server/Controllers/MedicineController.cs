using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Pillsmaster.API.Dtos;
using Pillsmaster.Application.Commands.Medicines.CreateMedicine;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.Medicines.Queries.GetMedicine;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicineController : BaseController
    {
        public MedicineController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        // GET api/<MedicineController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetAsync(Guid id, 
            CancellationToken cancellationToken)
        {
            try
            {
                var medicine = new Medicine();
                return Ok(medicine);
            }
            catch (NotFoundException e)
            {
                return NotFound($"Medicine not found (Exception: {e.Message})");
            }
        }

        /// <summary>
        /// GET api/<MedicineController>/GetByTradeName
        /// </summary>
        /// <param name="tradeName">Medicine trade name</param>
        /// <param name="cancellationToken">token</param>
        /// <returns>Medicine</returns>
        [HttpGet("GetByTradename/{tradeName}")]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetByTradeName(string tradeName,
            CancellationToken cancellationToken)
        {
            var query = new GetMedicineQuery()
            {
                TradeName = tradeName
            };
            var medicine = await _mediator.Send(query, cancellationToken);
            return Ok(medicine);
        }

        // POST api/<MedicineController>
        [HttpPost]
        public async Task<ActionResult<Medicine>> Post([FromBody] CreateMedicineDto createMedicineDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateMedicineCommand>(createMedicineDto);
            var medicine = await _mediator.Send(command, cancellationToken);
            return Ok(medicine);
        }

        // PUT api/<MedicineController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] MedicineViewModel medicineVm, 
            CancellationToken cancellationToken)
        {
            try
            {
                // await _medicineService.UpdateMedicine(id, medicineVm, cancellationToken);
                 return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound($"Medicine not found (Exception: {e.Message})");
            }
        }

        // DELETE api/<MedicineController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                // await _medicineService.DeleteMedicine(id, cancellationToken);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound($"Medicine not found (Exception: {e.Message})");
            }
        }
    }
}
