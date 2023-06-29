namespace FPFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initinit : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MealIngredient");
            AddPrimaryKey("dbo.MealIngredient", new[] { "MealID", "IngredientID" });
            DropColumn("dbo.MealIngredient", "MealsIngredientsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MealIngredient", "MealsIngredientsID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.MealIngredient");
            AddPrimaryKey("dbo.MealIngredient", "MealsIngredientsID");
        }
    }
}
