using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public partial class NaiveBayesClassifierContext : DbContext
    {
        public virtual DbSet<Bernoulli> Bernoullis { get; set; }
        public virtual DbSet<BernoulliTotal> BernoulliTotals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Polynomial> Polynomials { get; set; }
        public virtual DbSet<PolynomialTotal> PolynomialTotals { get; set; }
        public virtual DbSet<Vocabulary> Vocabularies { get; set; }

        private string ConnectionString()
        {
            var connectionString = new ConnectionString(nameof(NaiveBayesClassifierContext));

            return connectionString.Get();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConnectionString();

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Bernoulli>(entity =>
            {
                entity.ToTable(nameof(Bernoulli));

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Bernoullis)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bernoulli__Categ__412EB0B6");

                entity.HasOne(d => d.Total)
                    .WithMany(p => p.Bernoullis)
                    .HasForeignKey(d => d.TotalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bernoulli__Denom__4316F928");

                entity.HasOne(d => d.Vocabulary)
                    .WithMany(p => p.Bernoullis)
                    .HasForeignKey(d => d.VocabularyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bernoulli__Word__403A8C7D");
            });

            modelBuilder.Entity<BernoulliTotal>(entity =>
            {
                entity.ToTable(nameof(BernoulliTotal));

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BernoulliTotals)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bernoulli__Categ__3C69FB99");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable(nameof(Category));

                entity.HasIndex(e => e.Name, "UQ__Category__737584F6F9863918")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Polynomial>(entity =>
            {
                entity.ToTable(nameof(Polynomial));

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Polynomials)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Polynomia__Categ__4AB81AF0");

                entity.HasOne(d => d.Total)
                    .WithMany(p => p.Polynomials)
                    .HasForeignKey(d => d.TotalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Polynomia__Denom__4CA06362");

                entity.HasOne(d => d.Vocabulary)
                    .WithMany(p => p.Polynomials)
                    .HasForeignKey(d => d.VocabularyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Polynomial__Word__49C3F6B7");
            });

            modelBuilder.Entity<PolynomialTotal>(entity =>
            {
                entity.ToTable(nameof(PolynomialTotal));

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PolynomialTotals)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Polynomia__Categ__45F365D3");
            });

            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.ToTable(nameof(Vocabulary));

                entity.HasIndex(e => e.Word, "UQ__Vocabula__95B501089AAEE126")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}