using Microsoft.EntityFrameworkCore;
using NutritionDiary.Domain.Entities;

namespace NutritionDiary.Infrastructure.Persistence
{
    public class NutritionDbContext : DbContext
    {
        public NutritionDbContext(DbContextOptions<NutritionDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<DiaryEntry> DiaryEntries => Set<DiaryEntry>();
        public DbSet<FoodItem> FoodItems => Set<FoodItem>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItem>().OwnsOne(p => p.NutritionFacts);
            modelBuilder.Entity<DiaryEntry>().OwnsOne(d => d.NutritionTotalsSnapshot);

            modelBuilder.Entity<FoodItem>().ToTable("FoodItems");

            modelBuilder.Entity<DiaryEntry>()
                .HasOne(d => d.FoodItem)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<FoodItem>()
                .HasDiscriminator<string>("ItemType")
                .HasValue<Product>("Product");

            modelBuilder.Entity<DiaryEntry>()
                .Property(d => d.Meal)
                .HasConversion<string>();

            modelBuilder.Entity<Product>()
                .Property(p => p.NutriscoreGrade)
                .HasConversion<string>();

            modelBuilder.Entity<Product>()
                .Property(p => p.Source)
                .HasConversion<string>();
        }
    }
}
