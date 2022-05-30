using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MailService.DBModels
{
    public partial class NaiveBayesContext : DbContext
    {
        public NaiveBayesContext()
        {
        }

        //public NaiveBayesContext(DbContextOptions<NaiveBayesContext> options)
        //    : base(options)
        //{
        //}

        private string ConnectionString
            => ConfigurationManager.ConnectionStrings[nameof(NaiveBayesContext)].ConnectionString;
        public virtual DbSet<Bernoulli> Bernoullis { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Polynomial> Polynomials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Bernoulli>(entity =>
            {
                entity.ToTable(nameof(Bernoulli));

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasIndex(e => e.Word, "UQ__Models__95B50108E7FCB680")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Bernoulli)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.BernoulliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Models__Bernoull__5441852A");

                entity.HasOne(d => d.Polynomial)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.PolynomialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Models__Polynomi__5535A963");
            });

            modelBuilder.Entity<Polynomial>(entity =>
            {
                entity.ToTable(nameof(Polynomial));

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
