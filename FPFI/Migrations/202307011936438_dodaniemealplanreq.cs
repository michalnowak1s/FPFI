namespace FPFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniemealplanreq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MealPlan", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MealPlan", "Title", c => c.String(nullable: false));
        }
    }
}
