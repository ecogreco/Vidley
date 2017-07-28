namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertBirthday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '1/1/1980' WHERE id=1 ");
        }
        
        public override void Down()
        {
        }
    }
}
