using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patlus.Employment.UseCase.Entities;

namespace Patlus.Employment.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(e => e.EId)
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired(false);

            builder.Property(e => e.Phone)
                .IsRequired(false);

            builder.Property(e => e.Address)
                .IsRequired(true);

            builder.Property(e => e.CreatorId)
                .IsRequired();

            builder.Property(e => e.CreatedTime)
                .IsRequired();

            builder.Property(e => e.LastModifiedTime)
                .IsRequired();

            builder.Property(e => e.Archived)
                .IsRequired();

            builder.HasKey(e => e.Id);
        }
    }
}
