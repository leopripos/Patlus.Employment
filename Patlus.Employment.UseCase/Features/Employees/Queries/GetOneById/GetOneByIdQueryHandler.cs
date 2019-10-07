using Patlus.Common.UseCase;
using Patlus.Common.UseCase.Exceptions;
using Patlus.Employment.UseCase.Entities;
using Patlus.Employment.UseCase.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Employment.UseCase.Features.Employees.Queries.GetOneById
{
    public class GetOneByIdQueryHandler : IQueryFeatureHandler<GetOneByIdQuery, Employee>
    {
        private readonly IMasterDbContext dbService;

        public GetOneByIdQueryHandler(IMasterDbContext dbService)
        {
            this.dbService = dbService;
        }

        public Task<Employee> Handle(GetOneByIdQuery request, CancellationToken cancellationToken)
        {
            var query = dbService.Employees.Where(e => e.Id == request.Id);

            var entity = query.FirstOrDefault();

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            return Task.FromResult(entity);
        }
    }
}
