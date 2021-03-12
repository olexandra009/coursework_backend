using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=ec2-54-155-35-88.eu-west-1.compute.amazonaws.com;port=5432;user id=zrsztrqqgsxlkd;password=141a37dd9373aab8becdb45428f9b737826e868aa94b4bec50fdfa3da32e2f93;database=db3bnr04nspk0u;Pooling=true;SSLMode=Require; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.PasportNumber, "users_pasport_number_key")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.IpnNumber)
                    .HasMaxLength(10)
                    .HasColumnName("ipn_number");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.PasportNumber)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("pasport_number");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(30)
                    .HasColumnName("second_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
