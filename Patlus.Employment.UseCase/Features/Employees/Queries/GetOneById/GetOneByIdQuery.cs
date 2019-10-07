using Patlus.Common.UseCase;
using Patlus.Employment.UseCase.Entities;
using System;

namespace Patlus.Employment.UseCase.Features.Employees.Queries.GetOneById
{
    public class GetOneByIdQuery : IQueryFeature<Employee>
    {
        public Guid? Id { get; set; }
        public Guid? RequestorId { get; set; }
    }
}
