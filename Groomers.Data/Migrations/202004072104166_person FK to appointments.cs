namespace Groomers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personFKtoappointments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "PersonID", c => c.Int());
            CreateIndex("dbo.Appointment", "PersonID");
            AddForeignKey("dbo.Appointment", "PersonID", "dbo.Person", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "PersonID", "dbo.Person");
            DropIndex("dbo.Appointment", new[] { "PersonID" });
            DropColumn("dbo.Appointment", "PersonID");
        }
    }
}
