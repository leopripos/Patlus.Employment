using Patlus.Common.UseCase;
using System;

namespace Patlus.Employment.Rest.Features.Employees
{
    public class EmployeeDto : IDto
    {
        public Guid Id { get; set; }
        public string EId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }

        public Guid CreatorId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
