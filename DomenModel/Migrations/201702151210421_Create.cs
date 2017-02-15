namespace DomenModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.Int(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Salary = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfEmployment = c.DateTime(nullable: false),
                        DateOfDismissal = c.DateTime(),
                        Language = c.Int(nullable: false),
                        Nationality = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        IsReadyForMoving = c.Boolean(nullable: false),
                        IsReadyForBusinessTrip = c.Boolean(nullable: false),
                        DepartamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departament", t => t.DepartamentId)
                .Index(t => t.DepartamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartamentId", "dbo.Departament");
            DropIndex("dbo.Employee", new[] { "DepartamentId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Departament");
        }
    }
}
