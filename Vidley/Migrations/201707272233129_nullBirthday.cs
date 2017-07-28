namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullBirthday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '1/1/1900' WHERE Id=2 ");
        }
        
        public override void Down()
        {
        }
    }
}
