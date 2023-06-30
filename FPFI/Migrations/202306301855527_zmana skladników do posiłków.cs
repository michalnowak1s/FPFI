namespace FPFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmanaskladnikówdoposiłków : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MealIngredient");
            AddColumn("dbo.MealIngredient", "MealIngredientID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MealIngredient", "MealIngredientID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MealIngredient");
            DropColumn("dbo.MealIngredient", "MealIngredientID");
            AddPrimaryKey("dbo.MealIngredient", new[] { "MealID", "IngredientID" });
        }
    }
}
