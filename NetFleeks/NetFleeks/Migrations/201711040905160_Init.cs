namespace NetFleeks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        genreName = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            Sql(@"SET IDENTITY_INSERT [dbo].[Genres] ON
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (1, N'Comedy')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (2, N'Romance')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (3, N'Drama')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (4, N'Action')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (5, N'Horror')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (6, N'SciFi')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (7, N'Kids')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (8, N'Family')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (9, N'Biography')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (10, N'Adult')
            SET IDENTITY_INSERT [dbo].[Genres] OFF
            ");

            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        membershipType = c.String(nullable: false, maxLength: 100),
                        duration = c.Int(nullable: false),
                        payment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            Sql(@"SET IDENTITY_INSERT [dbo].[MembershipTypes] ON
            INSERT INTO [dbo].[MembershipTypes] ([ID], [membershipType], [duration], [payment]) VALUES (1, N'Free', 99999, 0)
            INSERT INTO [dbo].[MembershipTypes] ([ID], [membershipType], [duration], [payment]) VALUES (2, N'Premium', 12, 10)
            SET IDENTITY_INSERT [dbo].[MembershipTypes] OFF");
           
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        movieName = c.String(nullable: false, maxLength: 100),
                        genreID = c.Int(nullable: false),
                        dateAdded = c.DateTime(nullable: false),
                        releaseDate = c.DateTime(nullable: false),
                        actors = c.String(maxLength: 150),
                        summary = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.genreID, cascadeDelete: true)
                .Index(t => t.genreID);
            Sql(@"SET IDENTITY_INSERT [dbo].[Movies] ON
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (1, N'Forrest Gump', 3, N'2017-11-04 00:00:00', N'1994-09-30 00:00:00', N'Tom Hanks, Sally Field', N'
            JFK, LBJ, Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (3, N'The Wolf of Wall Street', 9, N'2017-11-04 00:00:00', N'2013-01-02 00:00:00', N' Leonardo DiCaprio, Jonah Hill, Margot Robbie', N'Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (4, N'The Notebook', 2, N'2017-11-04 00:00:00', N'2004-08-05 00:00:00', N'Ryan Gosling, Rachel McAdams', N'A poor yet passionate young man falls in love with a rich young woman, giving her a sense of freedom, but they are soon separated because of their social differences. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (5, N'Frozen', 7, N'2017-11-04 00:00:00', N'2013-11-28 00:00:00', N' Kristen Bell, Idina Menzel, Jonathan Groff ', N'When the newly crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister, Anna, teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (6, N'Inception', 6, N'2017-11-04 00:00:00', N'2010-07-22 00:00:00', N'NULL Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page', N'A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (7, N'Gladiator ', 4, N'2017-11-04 00:00:00', N'2000-05-18 00:00:00', N' Russell Crowe, Joaquin Phoenix, Connie Nielsen', N'When a Roman General is betrayed, and his family murdered by an emperor''s corrupt son, he comes to Rome as a gladiator to seek revenge. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (8, N'The Hangover', 1, N'2017-11-04 00:00:00', N'2009-07-30 00:00:00', N' Zach Galifianakis, Bradley Cooper, Justin Bartha', N'Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (9, N'Scream', 5, N'2017-11-04 00:00:00', N'1996-12-20 00:00:00', N' Neve Campbell, Courteney Cox, David Arquette ', N'A year after the murder of her mother, a teenage girl is terrorized by a new killer, who targets the girl and her friends by using horror films as part of a deadly game. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (10, N'Harry Potter and the Sorcerer''s Stone', 8, N'2017-11-04 00:00:00', N'2001-11-29 00:00:00', N'Daniel Radcliffe, Rupert Grint, Richard Harris ', N'Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [summary]) VALUES (11, N'Fifty Shades Darker', 10, N'2017-11-04 00:00:00', N'2017-02-09 00:00:00', N' Dakota Johnson, Jamie Dornan, Eric Johnson', N'While Christian wrestles with his inner demons, Anastasia must confront the anger and envy of the women who came before her. ')
            SET IDENTITY_INSERT [dbo].[Movies] OFF
            ");

            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        rentalExpiration = c.DateTime(nullable: false),
                        rentalMovie_ID = c.Int(),
                        rentalUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.rentalMovie_ID)
                .ForeignKey("dbo.Users", t => t.rentalUser_ID)
                .Index(t => t.rentalMovie_ID)
                .Index(t => t.rentalUser_ID);

            
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        fName = c.String(nullable: false, maxLength: 50),
                        lName = c.String(nullable: false, maxLength: 50),
                        gender = c.String(),
                        membershipTypeID = c.Int(nullable: false),
                        birth = c.DateTime(),
                        genreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.genreID, cascadeDelete: true)
                .ForeignKey("dbo.MembershipTypes", t => t.membershipTypeID, cascadeDelete: true)
                .Index(t => t.membershipTypeID)
                .Index(t => t.genreID);

            Sql(@"SET IDENTITY_INSERT [dbo].[Users] ON
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (3, N'Bar', N'Genish', N'Female', 2, N'1993-06-16 00:00:00', 1)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (4, N'Shaglant', N'Galanti', N'Female', 2, N'1993-04-06 00:00:00', 6)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (5, N'Adi', N'Haviv', N'Male', 2, N'1993-08-01 00:00:00', 4)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (6, N'Shai', N'Horovitz', N'Male', 2, N'1985-03-23 00:00:00', 2)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (7, N'Igor', N'Rochli', N'Male', 1, N'1975-04-28 00:00:00', 5)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (9, N'Nofar', N'Akrabi', N'Female', 1, N'1990-02-18 00:00:00', 1)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (10, N'Matan', N'Snir', N'Male', 1, N'1988-07-13 00:00:00', 2)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (11, N'Shaked', N'Galanti', N'Female', 2, N'1999-10-28 00:00:00', 8)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (12, N'Snir', N'Balgaly', N'Male', 2, N'1989-10-10 00:00:00', 10)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (14, N'Gal', N'Gelon', N'Female', 1, N'1978-12-31 00:00:00', 2)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (15, N'Merryman', N'Ethyl', N'female', 2, N'1991-05-11 00:00:00', 4)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (16, N'Admire', N'Arlena', N'male', 1, N'1966-07-08 00:00:00', 3)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (18, N'Lachapelle', N'Louetta', N'male', 1, N'1969-12-04 00:00:00', 3)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (21, N'Fabela', N'Monserrate', N'female', 2, N'1970-12-07 00:00:00', 3)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (22, N'Arrowsmith', N'Mica', N'female', 1, N'1972-12-08 00:00:00', 5)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (23, N'Dau', N'Corrie', N'female', 1, N'1977-04-01 00:00:00', 9)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (27, N'Swarthout', N'Kris', N'male', 2, N'1983-12-03 00:00:00', 1)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (29, N'Mace', N'David', N'male', 1, N'1988-05-07 00:00:00', 7)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (33, N'Kari', N'Chrystal', N'male', 1, N'1996-05-03 00:00:00', 8)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (34, N'Rylander', N'Yolanda', N'female', 1, N'1996-04-06 00:00:00', 1)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (40, N'Bosh', N'Juliette', N'female', 2, N'1993-09-05 00:00:00', 2)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (51, N'Riebel', N'Josefina', N'female', 1, N'1980-04-06 00:00:00', 2)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (52, N'Nero', N'Clint', N'male', 2, N'1980-02-12 00:00:00', 1)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (53, N'Dhillon', N'Dinorah', N'male', 2, N'1991-08-01 00:00:00', 6)
            INSERT INTO [dbo].[Users] ([ID], [fName], [lName], [gender], [membershipTypeID], [birth], [genreID]) VALUES (54, N'Linz', N'Gemma', N'female', 2, N'1964-11-03 00:00:00', 7)
            SET IDENTITY_INSERT [dbo].[Users] OFF
            ");
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9145fce2-f198-4dbd-a004-5eca6570fa9c', N'Manager')
            ");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bdcbddb0-5932-42c3-971e-2502aa232de9', N'9145fce2-f198-4dbd-a004-5eca6570fa9c')
            ");
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7af4f771-de01-4e9b-a3b8-d71066cf1b80', N'guest2@netfleeks.com', 0, N'AMTnSH8GNv8FM5vV957I+I4bMLelxuQ3eqDWXwluR2e+32mI6ObfwpuuUS3kQgPTOA==', N'2fd80d71-4ee1-40a5-9880-446e34e2f234', NULL, 0, 0, NULL, 1, 0, N'guest2@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9c53653d-dfec-47d8-95f4-6369eac4ace4', N'guest3@netfleeks.com', 0, N'AA1mu+9lXRSqPYuUsPgOKJ53LCr8wU/oJRxRtrbLjvXAYaNcIFPELt6Yb8woiaw7dQ==', N'a78be44a-9929-4b8e-bea6-07dac348c2b3', NULL, 0, 0, NULL, 1, 0, N'guest3@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bdcbddb0-5932-42c3-971e-2502aa232de9', N'admin@netfleeks.com', 0, N'AGzyf0zzNaAElt8HlNbGFHtczeiK+bAvQVjBiFScsmQRiZzvEX9SMv2EGtc/Ksfoag==', N'fc696eb4-86d0-494b-b778-7e223e12d4eb', NULL, 0, 0, NULL, 1, 0, N'admin@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e2de3cff-fbf6-4c29-99dd-a2b91466e169', N'genishbar@gmail.com', 0, N'AGDWHiCLH/05ukVsDoO5rg/Xxgn+HhQzd4Tb1ZwLXm77wVQiFVNKIlxY3ka7IzzP0g==', N'9ae572f7-a1c3-4f6d-9840-180ef6335877', NULL, 0, 0, NULL, 1, 0, N'genishbar@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f349766c-4b95-47d9-ba57-96bbf53f2dba', N'guest@netfleeks.com', 0, N'AL9U3Fc6vqE7yiEAfhbiqR+YKX/vod9KU7pH/+nMdxBfqvfcsHiNDgFBkAu22zpfKw==', N'd0ef8c2d-6f3a-4e29-be24-2fe1b033742d', NULL, 0, 0, NULL, 1, 0, N'guest@netfleeks.com')
            ");
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rentals", "rentalUser_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "membershipTypeID", "dbo.MembershipTypes");
            DropForeignKey("dbo.Users", "genreID", "dbo.Genres");
            DropForeignKey("dbo.Rentals", "rentalMovie_ID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "genreID", "dbo.Genres");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Users", new[] { "genreID" });
            DropIndex("dbo.Users", new[] { "membershipTypeID" });
            DropIndex("dbo.Rentals", new[] { "rentalUser_ID" });
            DropIndex("dbo.Rentals", new[] { "rentalMovie_ID" });
            DropIndex("dbo.Movies", new[] { "genreID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Rentals");
            DropTable("dbo.Movies");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Genres");
        }
    }
}
