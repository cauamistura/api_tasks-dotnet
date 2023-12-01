using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasks.Models;

namespace Tasks.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<Models.Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
