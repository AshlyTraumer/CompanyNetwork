namespace DomenModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Сitizenship", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "Nationality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Nationality", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "Сitizenship");
        }
    }
}
