using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityMangeSystem.Models;

namespace UniversityMangeSystem.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<WorkEntity>
    {
        public void Configure(EntityTypeBuilder<WorkEntity> builder)
        {
            builder
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(w => w.Author)
                .WithMany()
                .HasForeignKey(w => w.AuthorID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // Додано вказівку на ON DELETE NO ACTION

            builder
                .HasOne(w => w.Consultant)
                .WithMany()
                .HasForeignKey(w => w.ConsultantID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // Додано вказівку на ON DELETE NO ACTION
        }
    }
}
