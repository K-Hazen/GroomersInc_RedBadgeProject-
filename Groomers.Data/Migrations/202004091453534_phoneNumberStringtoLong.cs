namespace Groomers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phoneNumberStringtoLong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "PhoneNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "PhoneNumber", c => c.String(nullable: false));
        }
    }
}
