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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
