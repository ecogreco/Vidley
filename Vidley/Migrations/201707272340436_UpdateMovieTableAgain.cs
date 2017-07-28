namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieTableAgain : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies VALUES('Wall-E', '6/23/2008', 3)");
            Sql("INSERT INTO Movies VALUES('The Hangover', '5/30/2009', 1)");
            Sql("INSERT INTO Movies VALUES('Die Hard', '7/12/1988', 2)");
            Sql("INSERT INTO Movies VALUES('The Terminator', '10/26/1984', 2)");
            Sql("INSERT INTO Movies VALUES('Toy Story', '11/19/1995', 3)");
            Sql("INSERT INTO Movies VALUES('Titanic', '11/1/1997', 4)");

        }
        
        public override void Down()
        {
        }
    }
}
