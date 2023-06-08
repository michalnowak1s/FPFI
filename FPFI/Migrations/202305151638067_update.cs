namespace FPFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UnitID);
            
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
            
            AddColumn("dbo.Account", "Email", c => c.String());
            AddColumn("dbo.Ingredient", "UnitID", c => c.Int(nullable: false));
            AddColumn("dbo.Meal", "AccountID", c => c.Int(nullable: false));
            AlterColumn("dbo.Account", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Account", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Ingredient", "UnitID");
            CreateIndex("dbo.Meal", "AccountID");
            AddForeignKey("dbo.Ingredient", "UnitID", "dbo.Unit", "UnitID", cascadeDelete: true);
            AddForeignKey("dbo.Meal", "AccountID", "dbo.Account", "AccountID", cascadeDelete: true);
            DropColumn("dbo.Ingredient", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredient", "Unit", c => c.String());
            DropForeignKey("dbo.TagsMeal", "TagID", "dbo.Tag");
            DropForeignKey("dbo.TagsMeal", "MealID", "dbo.Meal");
            DropForeignKey("dbo.Meal", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Ingredient", "UnitID", "dbo.Unit");
            DropIndex("dbo.TagsMeal", new[] { "MealID" });
            DropIndex("dbo.TagsMeal", new[] { "TagID" });
            DropIndex("dbo.Meal", new[] { "AccountID" });
            DropIndex("dbo.Ingredient", new[] { "UnitID" });
            AlterColumn("dbo.Account", "Password", c => c.String());
            AlterColumn("dbo.Account", "Login", c => c.String());
            DropColumn("dbo.Meal", "AccountID");
            DropColumn("dbo.Ingredient", "UnitID");
            DropColumn("dbo.Account", "Email");
            DropTable("dbo.TagsMeal");
            DropTable("dbo.Tag");
            DropTable("dbo.Unit");
        }
    }
}
