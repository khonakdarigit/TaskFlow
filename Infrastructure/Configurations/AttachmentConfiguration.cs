using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Domain.Entities.Attachment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Attachment> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                 .HasOne(a => a.Task)
                 .WithMany(t => t.Attachments)
                 .HasForeignKey(a => a.TaskId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
