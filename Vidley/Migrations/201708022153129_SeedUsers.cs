namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5968b8e1-c4a4-4fe8-81dc-bf66dcd1e499', N'admin@vidley.com', 0, N'AKJ0wcst7gOS7CzWJsZhFklD5tobBZqG9wONOOHvwseZ2ytYrWkmdXp1NtglIqcRcQ==', N'b44ca50a-96d1-4d84-a1e8-88d3c40690ea', NULL, 0, 0, NULL, 1, 0, N'admin@vidley.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2d66a1d-b367-482c-bc6d-7c32b513cbfe', N'guest@vidley.com', 0, N'AHXwcmcIYL62aU+dky4kzP0kyV9Quvh1+77ECecsgO2+vJB4VeZeEs5aZiWAuCOaAQ==', N'3c07dbf4-2d6b-4795-ba2f-0347acce6526', NULL, 0, 0, NULL, 1, 0, N'guest@vidley.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'63738765-7964-4411-8f2e-44bb2c2dc181', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5968b8e1-c4a4-4fe8-81dc-bf66dcd1e499', N'63738765-7964-4411-8f2e-44bb2c2dc181')");
        }
        
        public override void Down()
        {
        }
    }
}
