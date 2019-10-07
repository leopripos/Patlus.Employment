using Patlus.Common.UseCase;
using Patlus.Employment.UseCase.Entities;
using System;
using System.Linq;

namespace Patlus.Employment.UseCase.Features.Employees.Queries.GetAll
{
    public class GetAllQuery : IQueryFeature<IQueryable<Employee>>
    {
        public Guid? RequestorId { get; set; }
    }
}
