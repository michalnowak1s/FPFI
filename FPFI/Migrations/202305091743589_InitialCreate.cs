namespace FPFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Nutriscore = c.String(),
                        Endurance = c.String(),
                        Allergen = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.IngredientID);
            
            CreateTable(
                "dbo.MealIngredient",
                c => new
                    {
                        MealsIngredientsID = c.Int(nullable: false, identity: true),
                        IngredientID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealsIngredientsID)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.IngredientID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        MealID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nationality = c.String(),
                        Nutriscore = c.String(),
                        Difficulty = c.String(),
                        TimeConsumption = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.MealID);
            
            CreateTable(
                "dbo.MealPlan",
                c => new
                    {
                        MealPlansID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                        MeakDay = c.DateTime(nullable: false),
                        Section = c.Int(nullable: false),
                        MealPlans_MealPlansID = c.Int(),
                    })
                .PrimaryKey(t => t.MealPlansID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.MealPlan", t => t.MealPlans_MealPlansID)
                .Index(t => t.AccountID)
                .Index(t => t.MealPlans_MealPlansID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealPlan", "MealPlans_MealPlansID", "dbo.MealPlan");
            DropForeignKey("dbo.MealPlan", "AccountID", "dbo.Account");
            DropForeignKey("dbo.MealIngredient", "MealID", "dbo.Meal");
            DropForeignKey("dbo.MealIngredient", "IngredientID", "dbo.Ingredient");
            DropIndex("dbo.MealPlan", new[] { "MealPlans_MealPlansID" });
            DropIndex("dbo.MealPlan", new[] { "AccountID" });
            DropIndex("dbo.MealIngredient", new[] { "MealID" });
            DropIndex("dbo.MealIngredient", new[] { "IngredientID" });
            DropTable("dbo.MealPlan");
            DropTable("dbo.Meal");
            DropTable("dbo.MealIngredient");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Account");
        }
    }
}
