namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, ReleaseDate, GenreId) VALUES('Shrek!', '4/22/2001', 3)");
        }
        
        public override void Down()
        {
        }
    }
}
