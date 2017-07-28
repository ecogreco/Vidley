namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES(1, 'Comedy')");
            Sql("INSERT INTO Genres VALUES(2, 'Action')");
            Sql("INSERT INTO Genres VALUES(3, 'Family')");
            Sql("INSERT INTO Genres VALUES(4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
