using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class UserTaskConfiguration : IEntityTypeConfiguration<Domain.Entities.UserTask>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.UserTask> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.AssignedToUser)
               .WithMany(f => f.Tasks)
               .HasForeignKey(c => c.AssignedToUserId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(c => c.CreatedByUser)
                .WithMany()
                .HasForeignKey(c => c.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
