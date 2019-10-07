using FluentValidation;
using Patlus.Common.UseCase;
using Patlus.Employment.UseCase.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Employment.UseCase.Features.Employees.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>, IFeatureValidator<CreateCommand>
    {
        private readonly IMasterDbContext dbService;

        public CreateCommandValidator(IMasterDbContext dbService)
        {
            this.dbService = dbService;

            RuleFor(r => r.EId)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(10)
                .MustAsync(UniqueCode);

            RuleFor(r => r.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(10);

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(r => r.Phone);

            RuleFor(r => r.Address)
                .NotEmpty();

            RuleFor(r => r.RequestorId)
                .NotEmpty();
        }

        public Task<bool> UniqueCode(CreateCommand command, string value, CancellationToken cancellationToken)
        {
            var count = dbService.Employees.Where(e => e.Name == value).Count();

            return Task.FromResult(count == 0);
        }
    }
}
