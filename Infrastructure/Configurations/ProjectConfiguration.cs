using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Domain.Entities.Project>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Project> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                 .HasOne(p => p.Owner)
                 .WithMany(u => u.OwnedProjects)
                 .HasForeignKey(p => p.OwnerId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
