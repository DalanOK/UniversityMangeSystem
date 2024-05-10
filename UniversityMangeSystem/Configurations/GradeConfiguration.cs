using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityMangeSystem.Models;

namespace UniversityMangeSystem.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<GradeEntity>
    {
        public void Configure(EntityTypeBuilder<GradeEntity> builder)
        {
            builder
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(g => g.Work)
                .WithOne()
                .HasForeignKey<GradeEntity>(g => g.WorkID)
                .IsRequired();
        }
    }
}

