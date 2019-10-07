using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patlus.Employment.Rest.Policies;
using Patlus.Employment.UseCase.Features.Employees.Commands.Create;
using Patlus.Employment.UseCase.Features.Employees.Queries.GetAll;
using Patlus.Employment.UseCase.Features.Employees.Queries.GetOneById;
using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Patlus.Employment.Rest.Features.Employees
{
    [ApiController]
    [Route("employees")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AccountsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = EmployeePolicy.Read)]
        public async Task<EmployeeDto[]> GetAll()
        {
            var result = await mediator.Send(new GetAllQuery());

            return mapper.ProjectTo<EmployeeDto>(result).ToArray();
        }

        [HttpGet("{employeeId}")]
        [Authorize(Policy = EmployeePolicy.Read)]
        public async Task<EmployeeDto> GetById(Guid employeeId)
        {
            var result = await mediator.Send(new GetOneByIdQuery() { Id = employeeId });

            return mapper.Map<EmployeeDto>(result);
        }

        [HttpPost]
        [Authorize(Policy = EmployeePolicy.Create)]
        public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateForm form)
        {
            var address = new UseCase.Entities.Address(
                form.Address.Street,
                form.Address.City,
                form.Address.State,
                form.Address.Country,
                form.Address.ZipCode
            );

            var command = new CreateCommand
            {
                EId = form.EId,
                Name = form.Name,
                Email = form.Email,
                Phone = form.Phone,
                Address = address,
                RequestorId = null
            };

            var account = await mediator.Send(command);

            return Created(new Uri($"{Request.Path}/{account.Id}", UriKind.Relative), mapper.Map<EmployeeDto>(account));
        }
    }
}
