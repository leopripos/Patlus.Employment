using Patlus.Common.UseCase;
using Patlus.Employment.UseCase.Entities;
using System;

namespace Patlus.Employment.UseCase.Features.Employees.Commands.Create
{
    public class CreateCommand : ICommandFeature<Employee>
    {
        public string EId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }

        public Guid? RequestorId { get; set; }
    }
}
