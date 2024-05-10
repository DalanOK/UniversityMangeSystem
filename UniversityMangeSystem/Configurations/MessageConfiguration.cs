using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UniversityMangeSystem.Models.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(m => m.Data).IsRequired().HasMaxLength(1000);

            // Зовнішні ключі та їх відношення з таблицями Users та Works
            builder.Property(m => m.SenderID).IsRequired();
            builder.HasOne(m => m.Sender)
                   .WithMany()
                   .HasForeignKey(m => m.SenderID)
                   .OnDelete(DeleteBehavior.Restrict); // або .OnDelete(DeleteBehavior.NoAction)

            builder.Property(m => m.ReceiverID).IsRequired();
            builder.HasOne(m => m.Receiver)
                   .WithMany()
                   .HasForeignKey(m => m.ReceiverID)
                   .OnDelete(DeleteBehavior.Restrict); // або .OnDelete(DeleteBehavior.NoAction)

            builder.Property(m => m.WorkID).IsRequired();
            builder.HasOne(m => m.Work)
                   .WithMany()
                   .HasForeignKey(m => m.WorkID)
                   .OnDelete(DeleteBehavior.Restrict); // або .OnDelete(DeleteBehavior.NoAction)

            builder.Property(m => m.DateSent).IsRequired().HasDefaultValueSql("GETDATE()");
        }
    }
}
