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
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (11, N'Thriller')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (12, N'Adventure')
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
                        membershipType = c.Int(nullable: false),
                        summary = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.genreID, cascadeDelete: true)
                .Index(t => t.genreID);

            Sql(@"SET IDENTITY_INSERT [dbo].[Movies] ON
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (1, N'Forrest Gump', 3, N'2017-11-04 00:00:00', N'1994-09-30 00:00:00', N'Tom Hanks, Sally Field', 1, N'
            JFK, LBJ, Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (3, N'The Wolf of Wall Street', 9, N'2017-11-04 00:00:00', N'2013-01-02 00:00:00', N' Leonardo DiCaprio, Jonah Hill, Margot Robbie', 2, N'Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (4, N'The Notebook', 2, N'2017-11-04 00:00:00', N'2004-08-05 00:00:00', N'Ryan Gosling, Rachel McAdams', 1, N'A poor yet passionate young man falls in love with a rich young woman, giving her a sense of freedom, but they are soon separated because of their social differences. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (5, N'Frozen', 7, N'2017-11-04 00:00:00', N'2013-11-28 00:00:00', N' Kristen Bell, Idina Menzel, Jonathan Groff ', 2, N'When the newly crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister, Anna, teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (6, N'Inception', 6, N'2017-11-04 00:00:00', N'2010-07-22 00:00:00', N'NULL Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page', 1, N'A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (7, N'Gladiator ', 4, N'2017-11-04 00:00:00', N'2000-05-18 00:00:00', N' Russell Crowe, Joaquin Phoenix, Connie Nielsen', 1, N'When a Roman General is betrayed, and his family murdered by an emperor''s corrupt son, he comes to Rome as a gladiator to seek revenge. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (8, N'The Hangover', 1, N'2017-11-04 00:00:00', N'2009-07-30 00:00:00', N' Zach Galifianakis, Bradley Cooper, Justin Bartha', 1, N'Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (9, N'Scream', 5, N'2017-11-04 00:00:00', N'1996-12-20 00:00:00', N' Neve Campbell, Courteney Cox, David Arquette ', 2, N'A year after the murder of her mother, a teenage girl is terrorized by a new killer, who targets the girl and her friends by using horror films as part of a deadly game. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (10, N'Harry Potter and the Sorcerer''s Stone', 8, N'2017-11-04 00:00:00', N'2001-11-29 00:00:00', N'Daniel Radcliffe, Rupert Grint, Richard Harris ', 2, N'Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry. ')
            INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (11, N'Fifty Shades Darker', 10, N'2017-11-04 00:00:00', N'2017-02-09 00:00:00', N' Dakota Johnson, Jamie Dornan, Eric Johnson', 1, N'While Christian wrestles with his inner demons, Anastasia must confront the anger and envy of the women who came before her. ')
            SET IDENTITY_INSERT [dbo].[Movies] OFF
            ");

            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        rentalUser = c.String(),
                        rentalExpiration = c.DateTime(nullable: false),
                        rentalMovie_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.rentalMovie_ID)
                .Index(t => t.rentalMovie_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cb3fc2b9-663f-4bb7-849e-cf086e5ae840', N'Manager')
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

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'90de9e1c-8eae-4642-8918-a52c6fcff28d', N'cb3fc2b9-663f-4bb7-849e-cf086e5ae840')
            ");

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        fName = c.String(nullable: false, maxLength: 50),
                        lName = c.String(nullable: false, maxLength: 50),
                        gender = c.String(nullable: false),
                        birth = c.DateTime(nullable: false),
                        membershipTypeID = c.Int(nullable: false),
                        genreID = c.Int(nullable: false),
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

            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'002e0b7c-9b1f-4030-83d8-226bdccbcdc0', N'Loraine', N'Mcmaster', N'male', N'1993-07-06 00:00:00', 0, 0, N'LoraineMcmaster@netfleeks.com', 0, N'ADY9H1/ZgmtaYaq3EBQm3656pkhxBuJmZi0eEW5jz2xuQM8Gt/ycksVZQmGTP2rxkA==', N'280c037e-59d4-4365-92d3-58b411f55f08', NULL, 0, 0, NULL, 1, 0, N'LoraineMcmaster@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0944aae4-927e-4f46-b271-bc23eb8b986f', N'Lettie', N'Levitt', N'female', N'1991-07-01 00:00:00', 0, 0, N'LettieLevitt@netfleeks.com', 0, N'AE0a52DCfvECf89l9ubEBmnKLy8JhCiuB4f5alNn9l4la3avo5Qeck0fARb02Oz4fQ==', N'fe2419ea-6706-49f3-b646-66bc50fd866c', NULL, 0, 0, NULL, 1, 0, N'LettieLevitt@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c636a49-3991-4caf-b6c9-9cd378361891', N'Modesto', N'Tanksley', N'Female', N'1980-01-01 00:00:00', 0, 0, N'ModestoTanksley@netfleeks.com', 0, N'AGbL1XuXCA9KLdhDG9yk6boLdBlM1PgxElLinGh3SdEcnQhrMS8rgJx7C6rLYcIRdQ==', N'672c3f76-8493-40e7-8679-2ee936e7c955', NULL, 0, 0, NULL, 1, 0, N'ModestoTanksley@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'12f417ab-1e86-4642-8512-7650c40bada6', N'Brook', N'Middlebrooks', N'male', N'1991-03-01 00:00:00', 0, 0, N'BrookMiddlebrooks@netfleeks.com', 0, N'AOEFiDxBirXsvj1o8KQSN7MYhcIqDwSHaDndMc21rM7ETwQpwXqJpq3K0S4bogcmhw==', N'd984d5b6-cd69-498a-ad14-7b0a02a40f7e', NULL, 0, 0, NULL, 1, 0, N'BrookMiddlebrooks@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1b84aed6-d11e-4e13-9713-cc400a09407e', N'Merryman', N'Ethyl', N'Male', N'1991-11-05 00:00:00', 0, 0, N'EthylMerryman@netfleeks.com', 0, N'AF7UinowtRZTcpcJHyYZnMkse7KtLfpe5sFfTxo8hiAHYXIu9oNwXdagccjTwane6A==', N'9a7d209a-1c1b-4ab9-af46-c6815b2f7a5a', NULL, 0, 0, NULL, 1, 0, N'EthylMerryman@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2c80d8cf-9e46-4874-9f85-efafdad0bb39', N'Mica', N'Arrowsmith', N'female', N'1972-08-12 00:00:00', 0, 0, N'MicaArrowsmith@netfleeks.com', 0, N'ABdTPC/ig954qFL9gNTqrT9zSB8RNpUnmPZVAZ+eiFDR2LwCjn7HeWafU2bwHElqlw==', N'dc92b4ad-76bc-4128-ba47-e93b8e84f3c3', NULL, 0, 0, NULL, 1, 0, N'MicaArrowsmith@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'32ea37c3-c454-41e8-b657-0856ea908995', N'Hwa', N'Josephson', N'male', N'1980-07-05 00:00:00', 0, 0, N'HwaJosephson@netfleeks.com', 0, N'AIV46cTn0athyN3xdX6Nq/2OOmlIBE2pw+suZ+YsTXvdZJXEtWCBhZn/NyBhOlfU1A==', N'c734ba36-3066-4e67-82c7-3a49fa9eb12a', NULL, 0, 0, NULL, 1, 0, N'HwaJosephson@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3679ea23-fe40-4b28-8613-2d1db2aed345', N'Arlena', N'Admire', N'male', N'1966-08-07 00:00:00', 0, 0, N'ArlenaAdmire@netfleeks.com', 0, N'AN2SbiurQhEaVBoRs7pohrTm343eFhQnq+x9RLj85QdcjG9Zs36Mig3iNg0PAgtczA==', N'e61a750a-b3a0-4341-98c4-059976893880', NULL, 0, 0, NULL, 1, 0, N'ArlenaAdmire@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a660a27-c70b-40c3-a2a6-e340695680ab', N'Marcia', N'Able', N'Female', N'1969-07-02 00:00:00', 0, 0, N'MarciaAble@netfleeks.com', 0, N'ALpg/RXHLWKLRR5MmPOvNglPZfj0FAOz4D18yhQrLZ/VrfPBlbgfhPJV99XAGYMLDw==', N'a35aca51-a5c3-4714-9835-eb7caf3e86ba', NULL, 0, 0, NULL, 1, 0, N'MarciaAble@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45715a90-af82-45b9-9ba9-6c6a1cd797c8', N'Fabela', N'Monserrate', N'female', N'1970-07-12 00:00:00', 0, 0, N'MonserrateFabela@netfleeks.com', 0, N'APZY7Dhit58b+cUg6mNDPn2m/o2vT86mUcO+OKOE9mmlhzotmAp3YvoEZPyIDDhtqA==', N'8c99b07a-ed2f-4cb1-835e-b17699cc9e55', NULL, 0, 0, NULL, 1, 0, N'MonserrateFabela@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4deb911c-5f3f-4534-9103-c43f0f802a6c', N'Melanie', N'Gates', N'Female', N'1991-02-02 00:00:00', 0, 0, N'MelanieGates@netfleeks.com', 0, N'AGQLZXIpAB3/urxyDSmV+CJk4LdJTEcTRue2dKBdP5/ihqhQea6D0RSksp+Hbvx6DQ==', N'b8254c50-4b9f-45bd-b03d-21cfec4ef436', NULL, 0, 0, NULL, 1, 0, N'MelanieGates@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54174d90-0650-47ba-a0c8-b8881a48063f', N'Corrie', N'Dau', N'male', N'1990-01-01 00:00:00', 0, 0, N'CorrieDau@netfleeks.com', 0, N'AFJbrXBGwcX48+jRgbA5w0p1DbYjVpb0UGmVi/2TjTsSalx4BNDV2lVsjxclBwjMMg==', N'2935066a-8912-419d-89e6-70fac8e5c856', NULL, 0, 0, NULL, 1, 0, N'CorrieDau@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5d8757d4-fe5a-4ca1-a010-6e0da2397c0d', N'Linnea', N'Vidaurri', N'male', N'1991-07-11 00:00:00', 0, 0, N'LinneaVidaurri@netfleeks.com', 0, N'AIRocUDKWpYwvbk2zCMgLKkoJb2Xs/d6y9gMxl47oYjmN/xOzE3UB7bDT5cO2uff/g==', N'21454798-fb10-4a3f-bc8c-4b47af43d419', NULL, 0, 0, NULL, 1, 0, N'LinneaVidaurri@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'637d7611-ca44-4e51-ae6c-8e85cc8c947b', N'David', N'Mace', N'male', N'1988-07-05 00:00:00', 0, 0, N'DavidMace@netfleeks.com', 0, N'AGbuTP2OEb1d8B2mkaUr1DwnuaJw6l/LKGgKUA00jnBrMD267cKhELDKFujZLAtymQ==', N'fbd26175-4bc6-4ff6-a6af-aff961179dcc', NULL, 0, 0, NULL, 1, 0, N'DavidMace@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'658a1fd0-7527-4bc1-80ac-047be66a4593', N'Dhillon', N'Dinorah', N'male', N'1991-01-08 00:00:00', 0, 0, N'DinorahDhillon@netfleeks.com', 0, N'AJqWWCF+2LI4Fo+LNNVzkhC/hw9JHGhTs1zQpfDXqBijoYMEm06+YiuU74ywUhzSNg==', N'f51fc8cd-0a2e-4f16-8ad5-86b33de8c73d', NULL, 0, 0, NULL, 1, 0, N'DinorahDhillon@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6dc30dce-0a15-4596-99e0-f0b58ff06490', N'Linz', N'Gemma', N'Female', N'1964-03-11 00:00:00', 0, 0, N'GemmaLinz@netfleeks.com', 0, N'AMcu/IvAVBjP8u3OAXsUgziDdI/eflH/Q97ULEs1r+q3OGPqWOqcdtAIL4SuMibJEQ==', N'deaa5899-9abc-485c-8aa4-e58c931f0b85', NULL, 0, 0, NULL, 1, 0, N'GemmaLinz@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'73c7adc9-6321-4c51-bba0-4f371c9de5b6', N'בר', N'גניש', N'בר גניש', N'1990-01-01 00:00:00', 0, 0, N'genishbar@gmail.com', 0, N'+qBqiNOutjR99purfJD5ffgq5DLyMOCkjA43J1g049IS44nvJL/el8iFA==
            ', N'b1fd2b71-b489-4630-96ec-4ead0c3ba226', NULL, 0, 0, NULL, 1, 0, N'genishbar@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90de9e1c-8eae-4642-8918-a52c6fcff28d', N'Admin', N'Admin', N'Female', N'1990-01-01 00:00:00', 0, 0, N'admin@netfleeks.com', 0, N'APgc8All1us+lIB0rYpQj1dsvfmmjPL/NY/o823wNfTq57VlhFQEbilFZd7h1B0HcQ==', N'611e7412-723e-437b-889a-d9456af8a9a6', NULL, 0, 0, NULL, 1, 0, N'admin@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'927d2c14-c082-454a-8e93-ced88d93cba5', N'Louie', N'Fulmer', N'male', N'1982-11-10 00:00:00', 0, 0, N'LouieFulmer@netfleeks.com', 0, N'ACqthdy5mgkiC04HerXs7MntGoiB2/esDU76oDy7TX4QROuG44oNzKUQv3aO2lv6Pw==', N'0e8e2a04-7db7-4815-b9f3-778afd222c7a', NULL, 0, 0, NULL, 1, 0, N'LouieFulmer@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b39e5ae4-6ad3-401d-a607-c908cd76e099', N'Kevin', N'Leedy', N'male', N'1982-10-12 00:00:00', 0, 0, N'KevinLeedy@netfleeks.com', 0, N'APgnN1iKwjU4VmWD3nakkhXT/XkQAzI9n4Jss4n4pZw7Ntp6oSa7r8lNE0Z8i7mw2A==', N'080fb082-3155-4285-8840-6ef912cd8631', NULL, 0, 0, NULL, 1, 0, N'KevinLeedy@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7df5533-177d-4cf0-a898-225207ccebe2', N'Kasha', N'Gallimore', N'male', N'1995-06-06 00:00:00', 0, 0, N'KashaGallimore@netfleeks.com', 0, N'AH6MHNDP58Uy7KN4Tzhl7GfIXtX3oITfAAlYNt4AN9RWo1fJQom+sY3u1SZxFVPHrA==', N'd9611769-ab63-4e0b-b971-be1e7f3665e0', NULL, 0, 0, NULL, 1, 0, N'KashaGallimore@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c06e2d4c-f7b9-4c5c-84c5-f73fd97f513d', N'Kris', N'Swarthout', N'male', N'1983-03-12 00:00:00', 0, 0, N'KrisSwarthout@netfleeks.com', 0, N'AAkfrVYbMCEKvvUKvggzIs+cicXUQ84l1NPQDqgDmClWYNNJhYlbLHmqfhYgskAaWw==', N'0a942ecb-1bac-40a2-9db8-d7736c755f52', NULL, 0, 0, NULL, 1, 0, N'KrisSwarthout@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c3dba52c-7937-4df3-9a07-93215dca3e9c', N'Josefina', N'Riebel', N'Female', N'1980-06-04 00:00:00', 0, 0, N'JosefinaRiebel@netfleeks.com', 0, N'AHfPXQa/TylmS/XS8d4TGsZhvjXe1MueMQMJDN4Z6gAhikL1Sf163FELTDfUhBamkA==', N'ed48e42b-2ede-4d77-84de-0bc31e7d8faf', NULL, 0, 0, NULL, 1, 0, N'JosefinaRiebel@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2f68248-e93c-43d0-ab6b-aa43ad0a6fd2', N'Aldo', N'Iacovelli', N'female', N'1979-02-05 00:00:00', 0, 0, N'AldoIacovelli@netfleeks.com', 0, N'AAvBDW04zc21d6hUN4k1rNrS7CsOPyNpM51SjnBPTaxY7fWaCoifCQWKh1eneDD2BA==', N'8b5bb30b-d2e7-4412-9edd-79a45785567f', NULL, 0, 0, NULL, 1, 0, N'AldoIacovelli@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd63db566-c9e1-4e88-859c-2569ae652564', N'Chantay', N'Blackwater', N'male', N'1984-07-07 00:00:00', 0, 0, N'ChantayBlackwater@netfleeks.com', 0, N'ALaKBaANNO4Q+YuSn5uYqhkPpeshmwwmT2DlvQMr8DmWilqXlF93WdjKmckPrRYadw==', N'bcb4bca7-576d-4bd8-8e0c-99f275e36b81', NULL, 0, 0, NULL, 1, 0, N'ChantayBlackwater@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dafa9647-2ab1-49d4-8438-21e50a3b717b', N'Clint', N'Nero', N'male', N'1980-12-02 00:00:00', 0, 0, N'ClintNero@netfleeks.com', 0, N'ALVqTDboGYI4gJs5eqZXY1gv1Q2C0NDpk2JIVlSeZS8k7zNFgEKb3T6a5vpZ6DLQVQ==', N'1138dfed-5b93-4361-a527-e2a4cb4fb1ef', NULL, 0, 0, NULL, 1, 0, N'ClintNero@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc8072de-4f6b-41f0-bfb3-6a9d6e899cb8', N'Chrystal', N'Kari', N'male', N'1996-03-05 00:00:00', 0, 0, N'ChrystalKari@netfleeks.com', 0, N'AP/OPnuc4DZ9bYqEm43hF+TxYtXb85+GEtKT65Q3otG+yRkmMguDixskMsTEK9Q/BQ==', N'62214218-f8f2-406e-a4a0-be327ea5a8d6', NULL, 0, 0, NULL, 1, 0, N'ChrystalKari@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd005e61-674c-41af-8b18-f87bf3d6fe06', N'Yolanda', N'Rylander', N'female', N'1996-06-04 00:00:00', 0, 0, N'YolandaRylander@netfleeks.com', 0, N'AFaEYdnWGquVTJ2/l5Pmm/EaN2umvZteipOoFNyLrgCk8y7fjmcqn4enmcl3kO54RQ==', N'a65dc6da-6798-4d16-b028-2c7fdd658824', NULL, 0, 0, NULL, 1, 0, N'YolandaRylander@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea32605b-0005-4d72-911f-a7362670f205', N'Louetta', N'Lachapelle', N'male', N'1969-04-12 00:00:00', 0, 0, N'LouettaLachapelle@netfleeks.com', 0, N'AKpFB71buRivWB009sc+/Bq+rG124Fw21g0E34GYYQTHppZV1JstJVhuOOWBBLug7g==', N'4c765c0f-a885-4c97-a4d9-e4fc56bd0ae9', NULL, 0, 0, NULL, 1, 0, N'LouettaLachapelle@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eaf4776d-f0a9-4abd-bf12-013a235d8a97', N'Jaleesa', N'Polite', N'female', N'1987-01-04 00:00:00', 0, 0, N'JaleesaPolite@netfleeks.com', 0, N'AOre78uSQ44jhnsPoLvbGlkn8LhgLLiaO3dBrbyUCncEK5DEgffc4kJFNDbjffBoQQ==', N'15be2794-2545-4cfe-b195-2126966a022c', NULL, 0, 0, NULL, 1, 0, N'JaleesaPolite@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3e8f596-67b2-45d6-8efd-2d3f3824642b', N'Juliette', N'Bosh', N'female', N'1993-05-09 00:00:00', 0, 0, N'JulietteBosh@netfleeks.com', 0, N'ACg7qOeq0vnxrpOslBPwFSLWhwIE/LJzupEpKhAUnS1DLiygCO1kctVAnn+kuIQvLQ==', N'2d250bb9-46e5-4053-8dc3-ece599f21fc5', NULL, 0, 0, NULL, 1, 0, N'JulietteBosh@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ff774146-cf5c-453a-b17d-48965e43b28c', N'Velva', N'Collett', N'female', N'1996-02-12 00:00:00', 0, 0, N'VelvaCollett@netfleeks.com', 0, N'AJaD5JhFyS+m1xtA5ArIg59jyJ7NDP9D2nCmTqFfqMmpb1XkmGfk1LfRFH0LdJQBQA==', N'86c11ffb-2e9a-440c-adb2-cc50c5d64820', NULL, 0, 0, NULL, 1, 0, N'VelvaCollett@netfleeks.com')
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
            DropForeignKey("dbo.Rentals", "rentalMovie_ID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "genreID", "dbo.Genres");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Rentals", new[] { "rentalMovie_ID" });
            DropIndex("dbo.Movies", new[] { "genreID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rentals");
            DropTable("dbo.Movies");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Genres");
        }
    }
}
