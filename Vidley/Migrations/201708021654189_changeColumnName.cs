namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
            DropColumn("dbo.MembershipTypes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Type", c => c.String(nullable: false));
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
