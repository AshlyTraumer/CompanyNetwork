namespace DomenModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigraDescription : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitizenshipDescription",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
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
                        Sex = c.Int(nullable: false),
                        IsReadyForMoving = c.Boolean(nullable: false),
                        IsReadyForBusinessTrip = c.Boolean(nullable: false),
                        DepartamentId = c.Int(nullable: false),
                        CitizenshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departament", t => t.DepartamentId)
                .ForeignKey("dbo.CitizenshipDescription", t => t.CitizenshipId, cascadeDelete: true)
                .Index(t => t.DepartamentId)
                .Index(t => t.CitizenshipId);
            
            CreateTable(
                "dbo.Departament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "CitizenshipId", "dbo.CitizenshipDescription");
            DropForeignKey("dbo.Employee", "DepartamentId", "dbo.Departament");
            DropIndex("dbo.Employee", new[] { "CitizenshipId" });
            DropIndex("dbo.Employee", new[] { "DepartamentId" });
            DropTable("dbo.Departament");
            DropTable("dbo.Employee");
            DropTable("dbo.CitizenshipDescription");
        }
    }
}
