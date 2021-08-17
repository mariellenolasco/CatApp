using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatData.Entities
{
    public partial class CatDBContext : DbContext
    {
        public CatDBContext()
        {
        }

        public CatDBContext(DbContextOptions<CatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cat>(entity =>
            {
                entity.ToTable("cats");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("meals");

                entity.Property(e => e.Time).HasColumnType("date");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__meals__CatId__60A75C0F");

                entity.HasOne(d => d.FoodTypeNavigation)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.FoodType)
                    .HasConstraintName("FK__meals__FoodType__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
