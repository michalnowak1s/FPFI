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

        public DbSet<Account> Account { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<MealPlans> MealPlans { get; set; }
        public DbSet<Meals> Meals { get; set; }
        public DbSet<MealsIngredients> MealsIngredients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}