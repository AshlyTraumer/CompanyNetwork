namespace DomenModel.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MigraDescription1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Citizenship", "dbo.CitizenshipDescription");
            AddForeignKey("dbo.Employee", "Citizenship", "dbo.CitizenshipDescription", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Citizenship", "dbo.CitizenshipDescription");
            AddForeignKey("dbo.Employee", "Citizenship", "dbo.CitizenshipDescription", "Id", cascadeDelete: true);
        }
    }
}
