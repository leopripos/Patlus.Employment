using Microsoft.EntityFrameworkCore;
using Patlus.Common.UseCase.Services;
using Patlus.Employment.Persistence.Configurations;
using Patlus.Employment.UseCase.Entities;
using Patlus.Employment.UseCase.Services;
using System.Linq;

namespace Patlus.Employment.Persistence.Contexts
{
    public class MasterDbContext : DbContext, IMasterDbContext
    {
        private readonly ITimeService timeService;

        public MasterDbContext(DbContextOptions<MasterDbContext> options, ITimeService timeService)
            : base(options)
        {
            this.timeService = timeService;
        }

        public IQueryable<Employee> Employees
        {
            get { return Set<Employee>(); }
        }

        void IMasterDbContext.Add<TEntity>(TEntity entity)
        {
            Set<TEntity>().Add(entity);
        }

        void IMasterDbContext.Update<TEntity>(TEntity entity)
        {
            Set<TEntity>().Update(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
