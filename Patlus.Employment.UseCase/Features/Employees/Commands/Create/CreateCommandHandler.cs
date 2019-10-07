using MediatR;
using Microsoft.Extensions.Logging;
using Patlus.Common.UseCase;
using Patlus.Common.UseCase.Services;
using Patlus.Employment.UseCase.Entities;
using Patlus.Employment.UseCase.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Employment.UseCase.Features.Employees.Commands.Create
{
    public class CreateCommandHandler : ICommandFeatureHandler<CreateCommand, Employee>
    {
        private readonly ILogger<CreateCommandHandler> logger;
        private readonly IMasterDbContext dbService;
        private readonly ITimeService timeService;
        private readonly IMediator mediator;

        public CreateCommandHandler(ILogger<CreateCommandHandler> logger, IMasterDbContext dbService, ITimeService timeService, IMediator mediator)
        {
            this.logger = logger;
            this.dbService = dbService;
            this.timeService = timeService;
            this.mediator = mediator;
        }

        public async Task<Employee> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var currentTime = timeService.Now;

            var entity = new Employee()
            {
                Id = Guid.NewGuid(),
                EId = request.EId,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                CreatorId = request.RequestorId.Value,
                CreatedTime = currentTime,
                LastModifiedTime = currentTime,
            };

            dbService.Add(entity);

            await dbService.SaveChangesAsync(cancellationToken);

            var notification = new CreatedNotification
            {
                Entity = entity,
                By = request.RequestorId.Value,
                Time = currentTime
            };

            try
            {
                await mediator.Publish(notification, cancellationToken);
            }
            catch (Exception e)
            {
                logger.LogError(e, $"Error publish {nameof(CreatedNotification)} when handle { nameof(CreateCommand) } at { nameof(CreateCommandHandler) }");
            }

            return entity;
        }
    }
}
