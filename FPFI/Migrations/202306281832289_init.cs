namespace FPFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MealIngredient1", "Meal_MealID", "dbo.Meal");
            DropForeignKey("dbo.MealIngredient1", "Ingredient_IngredientID", "dbo.Ingredient");
            DropIndex("dbo.MealIngredient1", new[] { "Meal_MealID" });
            DropIndex("dbo.MealIngredient1", new[] { "Ingredient_IngredientID" });
            DropTable("dbo.MealIngredient1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MealIngredient1",
                c => new
                    {
                        Meal_MealID = c.Int(nullable: false),
                        Ingredient_IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meal_MealID, t.Ingredient_IngredientID });
            
            CreateIndex("dbo.MealIngredient1", "Ingredient_IngredientID");
            CreateIndex("dbo.MealIngredient1", "Meal_MealID");
            AddForeignKey("dbo.MealIngredient1", "Ingredient_IngredientID", "dbo.Ingredient", "IngredientID", cascadeDelete: true);
            AddForeignKey("dbo.MealIngredient1", "Meal_MealID", "dbo.Meal", "MealID", cascadeDelete: true);
        }
    }
}
