namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstertDateAdded : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET DateAdded = '5/4/2016' WHERE Id >= 3");
            Sql("UPDATE Movies SET DateAdded = '1/15/2016' WHERE Id < 3");

        }
        
        public override void Down()
        {
        }
    }
}
