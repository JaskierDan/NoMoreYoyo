using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NoMoreYoyo.Models
{
    public partial class NoMoreYoyoContext : DbContext
    {
        public NoMoreYoyoContext()
        {
        }

        public NoMoreYoyoContext(DbContextOptions<NoMoreYoyoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyAttribute> BodyAttributes { get; set; }
        public virtual DbSet<Calory> Calories { get; set; }
        public virtual DbSet<MeasurementType> MeasurementTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hungarian_CI_AS");

            modelBuilder.Entity<BodyAttribute>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(6, 0)");

                entity.HasOne(d => d.MeasurementType)
                    .WithMany(p => p.BodyAttributes)
                    .HasForeignKey(d => d.MeasurementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BodyAttri__Measu__2A4B4B5E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BodyAttributes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BodyAttri__UserI__2B3F6F97");
            });

            modelBuilder.Entity<Calory>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Carbohydrates).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Fats).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Proteins).HasColumnType("decimal(6, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Calories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Calories__UserId__2C3393D0");
            });

            modelBuilder.Entity<MeasurementType>(entity =>
            {
                entity.ToTable("MeasurementType");

                entity.Property(e => e.Metric)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.EmailAddress).IsRequired();

                entity.Property(e => e.Height).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.RegisteredDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(6, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
