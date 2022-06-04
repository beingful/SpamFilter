using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public partial class NaiveBayesContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Fraction> Fractions { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Vocabulary> Vocabularies { get; set; }
        public virtual DbSet<WordInModel> WordInModels { get; set; }

        private string GetConnectionString()
        {
            var connectionString = new ConnectionString(nameof(NaiveBayesContext));

            return connectionString.Get();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = GetConnectionString();

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable(nameof(Category));

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Fraction>(entity =>
            {
                entity.ToTable(nameof(Fraction));

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable(nameof(Model));

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CorrespondenceNavigation)
                    .WithMany(p => p.ModelCorrespondenceNavigations)
                    .HasForeignKey(d => d.Correspondence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Model__Correspon__236943A5");

                entity.HasOne(d => d.SpamNavigation)
                    .WithMany(p => p.ModelSpamNavigations)
                    .HasForeignKey(d => d.Spam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Model__Spam__22751F6C");
            });

            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.ToTable(nameof(Vocabulary));

                entity.HasIndex(e => e.Word, "UQ__Vocabula__95B501084DFF92C9")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<WordInModel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.WordInModel)
                    .HasForeignKey<WordInModel>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WordInModels__Id__29221CFB");

                entity.HasOne(d => d.MultinomialNavigation)
                    .WithMany(p => p.WordInModelMultinomialNavigations)
                    .HasForeignKey(d => d.Multinomial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WordInMod__Multi__2A164134");

                entity.HasOne(d => d.PolynomialNavigation)
                    .WithMany(p => p.WordInModelPolynomialNavigations)
                    .HasForeignKey(d => d.Polynomial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WordInMod__Polyn__2B0A656D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}