using FPFI.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FPFI.DAL
{
    public class FPFIContext : DbContext
    {
        public FPFIContext() : base("FPFIContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsMeal> TagsMeals { get; set; }
        public DbSet<Unit> Units { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}