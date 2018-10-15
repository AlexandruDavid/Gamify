namespace Gamify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2eec3b4c-4f6a-405c-af05-3297c5b90569', N'guest@gamify.com', 0, N'AMUczrqlU2foTLvD6n4qN1qdXBCyaw7rF21ZomO56dYxCEkg9mefoEfN6MaDXZ0kFw==', N'17a5e0d6-7d29-42ff-852d-3b119e31828c', NULL, 0, 0, NULL, 1, 0, N'guest@gamify.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'65a37a32-e972-4225-ad75-a5b07067111d', N'admin@gamify.com', 0, N'AIHE6tV5zu6HYld+Kr4/sc5VvOuRMQm4d4Ij7d+noOl7N30RGvV56h+ET6Uaxb7ZJg==', N'21d40627-360d-49bf-b034-4b43ea704264', NULL, 0, 0, NULL, 1, 0, N'admin@gamify.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f82f00d2-f436-459b-839d-827c2c90e2df', N'CanManageGames')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'65a37a32-e972-4225-ad75-a5b07067111d', N'f82f00d2-f436-459b-839d-827c2c90e2df')");
        }
        
        public override void Down()
        {
        }
    }
}
