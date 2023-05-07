using FPFI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

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
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}