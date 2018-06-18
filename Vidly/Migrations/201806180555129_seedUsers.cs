namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'da89f5c8-e777-431c-b3fd-f112aa048fd3', N'guest@vidly.com', 0, N'AO5DjBP6sbkUiu8UVPeaMVonN+LCQK+BnxGG8bTQF2SZXECGQQJr/NJ4ZtrNNrWvfg==', N'c8db18d9-3335-4e93-89cd-1599a7a4b51e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eea65ead-f7f6-4158-9c93-fa421823e920', N'admin@vidly.com', 0, N'AB4GgwwLp7eZB5pg/v2/XxynKknG5s32td9weM1Cy9jtBXHsJbrHNrR55nv3fUapJA==', N'5778bf67-9c69-49d1-b4ec-e9462390fabd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1775d0f3-9edd-4c55-8b30-1f1dd16dd027', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eea65ead-f7f6-4158-9c93-fa421823e920', N'1775d0f3-9edd-4c55-8b30-1f1dd16dd027')
");

        }
        
        public override void Down()
        {
        }
    }
}
