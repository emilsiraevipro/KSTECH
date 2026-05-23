using KSTECH.Domain.Modules;
using KSTECH.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace KSTECH.Infrastructure.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        void IEntityTypeConfiguration<Module>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("modules");

            builder.HasKey(m => m.id);

            builder.Property(m => m.id)
                .HasConversion(id => id.Value, value => ModuleId.Create(value));

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.HasMany(m => m.Issues)
                .WithOne()
                .HasForeignKey("module_id");
        }
    }
}
