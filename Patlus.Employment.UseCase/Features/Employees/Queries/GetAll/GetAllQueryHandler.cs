using Patlus.Common.UseCase;
using Patlus.Employment.UseCase.Entities;
using Patlus.Employment.UseCase.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Employment.UseCase.Features.Employees.Queries.GetAll
{
    public class GetAllQueryHandler : IQueryFeatureHandler<GetAllQuery, IQueryable<Employee>>
    {
        private readonly IMasterDbContext dbService;

        public GetAllQueryHandler(IMasterDbContext dbService)
        {
            this.dbService = dbService;
        }

        public Task<IQueryable<Employee>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var query = dbService.Employees;

            return Task.FromResult(query);
        }
    }
}
