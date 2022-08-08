using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pillsmaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService, IPillsmasterDbContext dbContext)
        {
            _medicineService = medicineService;
        }

        // GET api/<MedicineController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetAsync(Guid id, 
            CancellationToken cancellationToken)
        {
            try
            {
                var medicine = await _medicineService.ReadMedicineById(id, cancellationToken);
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
            try
            {
                var medicine = await _medicineService.ReadMedicinesByName(tradeName, cancellationToken);
                return Ok(medicine);
            }
            catch (NotFoundException e)
            {
                return NotFound($"Medicine not found (Exception: {e.Message})");
            }
        }

        // POST api/<MedicineController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] MedicineViewModel medicineVm,
            CancellationToken cancellationToken)
        {
            var medicineId = await _medicineService.CreateMedicine(medicineVm, cancellationToken);
            return Ok(medicineId);
        }

        // PUT api/<MedicineController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] MedicineViewModel medicineVm, 
            CancellationToken cancellationToken)
        {
            try
            {
                await _medicineService.UpdateMedicine(id, medicineVm, cancellationToken);
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
                await _medicineService.DeleteMedicine(id, cancellationToken);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound($"Medicine not found (Exception: {e.Message})");
            }
        }
    }
}
