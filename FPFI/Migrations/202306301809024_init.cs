namespace FPFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(),
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
                        UnitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("dbo.Unit", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.UnitID);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UnitID);
            
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
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.MealIngredient",
                c => new
                    {
                        MealID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealID, t.IngredientID })
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.MealID)
                .Index(t => t.IngredientID);
            
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
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.TagsMeal",
                c => new
                    {
                        TagsMealID = c.Int(nullable: false, identity: true),
                        TagID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagsMealID)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.MealID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagsMeal", "TagID", "dbo.Tag");
            DropForeignKey("dbo.TagsMeal", "MealID", "dbo.Meal");
            DropForeignKey("dbo.MealPlan", "MealPlans_MealPlansID", "dbo.MealPlan");
            DropForeignKey("dbo.MealPlan", "AccountID", "dbo.Account");
            DropForeignKey("dbo.MealIngredient", "MealID", "dbo.Meal");
            DropForeignKey("dbo.MealIngredient", "IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.Meal", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Ingredient", "UnitID", "dbo.Unit");
            DropIndex("dbo.TagsMeal", new[] { "MealID" });
            DropIndex("dbo.TagsMeal", new[] { "TagID" });
            DropIndex("dbo.MealPlan", new[] { "MealPlans_MealPlansID" });
            DropIndex("dbo.MealPlan", new[] { "AccountID" });
            DropIndex("dbo.MealIngredient", new[] { "IngredientID" });
            DropIndex("dbo.MealIngredient", new[] { "MealID" });
            DropIndex("dbo.Meal", new[] { "AccountID" });
            DropIndex("dbo.Ingredient", new[] { "UnitID" });
            DropTable("dbo.TagsMeal");
            DropTable("dbo.Tag");
            DropTable("dbo.MealPlan");
            DropTable("dbo.MealIngredient");
            DropTable("dbo.Meal");
            DropTable("dbo.Unit");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Account");
        }
    }
}
