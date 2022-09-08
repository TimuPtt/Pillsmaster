using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Pillsmaster.API.Dtos;
using Pillsmaster.Application.UserMedicines.Commands.CreateUserMedicine;
using Pillsmaster.Application.UserMedicines.Commands.DeleteUserMedicine;
using Pillsmaster.Application.UserMedicines.Commands.UpdateUserMedicine;
using Pillsmaster.Application.UserMedicines.Queries.GetUserMedicines;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserMedicineController : BaseController
    {
        public UserMedicineController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
        
        // GET: api/<UserMedicineController>
        [HttpGet]
        public async Task<ActionResult<List<UserMedicineViewModel>>> GetUserMedicines(
            CancellationToken cancellationToken)
        {
            var query = new GetUserMedicinesQuery()
            {
                UserId = UserId
            };
            var userMedicines = await _mediator.Send(query, cancellationToken);
            return Ok(userMedicines);
        }

        // POST api/<UserMedicineController>
        [HttpPost]
        public async Task<ActionResult<UserMedicine>> Post([FromBody] CreateUserMedicineDto createUserMedicineDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateUserMedicineCommand>(createUserMedicineDto);
            command.UserId = UserId;
            var userMedicine = await _mediator.Send(command, cancellationToken);
            return Ok(userMedicine);
        }

        // PUT api/<UserMedicineController>/5
        [HttpPut]
        public async Task<ActionResult<UserMedicine>> Put(UpdateUserMedicineDto updateUserMedicineDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateUserMedicineCommand>(updateUserMedicineDto);
            command.UserId = UserId;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<UserMedicineController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserMedicine>> Delete(Guid id)
        {
            var command = new DeleteUserMedicineCommand()
            {
                Id = id,
                UserId = UserId
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
