namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNameToDateRented : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rentals", "RentalDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "RentalDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rentals", "DateRented");
        }
    }
}
