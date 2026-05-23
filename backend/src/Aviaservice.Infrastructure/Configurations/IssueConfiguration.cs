using KSTECH.Domain.Modules;
using KSTECH.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace KSTECH.Infrastructure.Configurations
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        void IEntityTypeConfiguration<Issue>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issues");

            builder.HasKey(i => i.id);

            builder.Property(i => i.id)
                .HasConversion(id => id.Value, value => IssueId.Create(value));

            builder.Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(i => i.LessonId)
                .IsRequired(false);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.HasOne(i => i.ParentIssue)
                .WithMany(pi => pi.SubIssues)
                .HasForeignKey("parent_id")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(i => i.Details, ib =>
            {
                ib.ToJson();
                ib.OwnsMany(d => d.Files, fb =>
                {
                    fb.Property(f => f.PathToStorage).IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                });
            });
               
        }
    }
}
