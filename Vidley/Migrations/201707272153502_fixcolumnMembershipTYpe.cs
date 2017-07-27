namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcolumnMembershipTYpe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Type", c => c.String());
        }
    }
}
