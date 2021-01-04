using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.PersonalInfoDataBase
{
    public partial class PersonalUsersInfoContext : DbContext
    {
        public PersonalUsersInfoContext()
        {
        }

        public PersonalUsersInfoContext(DbContextOptions<PersonalUsersInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IpnNumber)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ipn_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PasportNumber)
                    .IsRequired()
                    .HasColumnType("varchar(9)")
                    .HasColumnName("pasport_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SecondName)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("second_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
