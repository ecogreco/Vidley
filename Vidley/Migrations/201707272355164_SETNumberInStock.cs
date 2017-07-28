namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SETNumberInStock : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberInStock = 5");
        }
        
        public override void Down()
        {
        }
    }
}
