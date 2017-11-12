namespace NetFleeks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        cinemaName = c.String(nullable: false, maxLength: 100),
                        cinemaAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            Sql(@"SET IDENTITY_INSERT [dbo].[Cinemas] ON
            INSERT INTO [dbo].[Cinemas] ([ID], [cinemaName], [cinemaAddress]) VALUES (1, N'Cinema City', N'31.9838445,34.77120650000006')
            INSERT INTO [dbo].[Cinemas] ([ID], [cinemaName], [cinemaAddress]) VALUES (2, N'Yes Planet', N'31.9796641,34.747589500000004')
            SET IDENTITY_INSERT [dbo].[Cinemas] OFF
            ");

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
SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (1, N'Forrest Gump', 3, N'2017-11-04 00:00:00', N'1994-09-09 00:00:00', N'Tom Hanks, Sally Field', 1, N'JFK, LBJ, Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (3, N'The Wolf of Wall Street', 9, N'2017-11-04 00:00:00', N'2013-01-02 00:00:00', N' Leonardo DiCaprio, Jonah Hill, Margot Robbie', 2, N'Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (4, N'The Notebook', 2, N'2017-11-04 00:00:00', N'2004-08-05 00:00:00', N'Ryan Gosling, Rachel McAdams', 1, N'A poor yet passionate young man falls in love with a rich young woman, giving her a sense of freedom, but they are soon separated because of their social differences. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (5, N'Frozen', 7, N'2017-11-04 00:00:00', N'2013-11-01 00:00:00', N' Kristen Bell, Idina Menzel, Jonathan Groff ', 2, N'When the newly crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister, Anna, teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (6, N'Inception', 6, N'2017-11-04 00:00:00', N'2010-07-02 00:00:00', N'NULL Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page', 1, N'A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (7, N'Gladiator', 4, N'2017-11-04 00:00:00', N'2000-05-09 00:00:00', N' Russell Crowe, Joaquin Phoenix, Connie Nielsen', 1, N'When a Roman General is betrayed, and his family murdered by an emperor''s corrupt son, he comes to Rome as a gladiator to seek revenge. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (8, N'The Hangover', 1, N'2017-11-04 00:00:00', N'2009-07-04 00:00:00', N' Zach Galifianakis, Bradley Cooper, Justin Bartha', 1, N'Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (9, N'Scream', 5, N'2017-11-04 00:00:00', N'1996-12-11 00:00:00', N' Neve Campbell, Courteney Cox, David Arquette ', 2, N'A year after the murder of her mother, a teenage girl is terrorized by a new killer, who targets the girl and her friends by using horror films as part of a deadly game. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (10, N'Harry Potter and the Sorcerer''s Stone', 8, N'2017-11-04 00:00:00', N'2001-11-09 00:00:00', N'Daniel Radcliffe, Rupert Grint, Richard Harris ', 2, N'Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (11, N'Fifty Shades Darker', 10, N'2017-11-04 00:00:00', N'2017-02-09 00:00:00', N' Dakota Johnson, Jamie Dornan, Eric Johnson', 1, N'While Christian wrestles with his inner demons, Anastasia must confront the anger and envy of the women who came before her. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (13, N'Leon', 11, N'2017-11-12 00:00:00', N'1994-09-12 00:00:00', N' Jean Reno, Gary Oldman, Natalie Portman |', 1, N' Mathilda, a 12-year-old girl, is reluctantly taken in by Léon, a professional assassin, after her family is murdered. Léon and Mathilda form an unusual relationship, as she becomes his protégée and learns the assassin''s trade. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (14, N'Pay The Ghost', 11, N'2017-11-12 00:00:00', N'2016-02-04 00:00:00', N'Nicolas Cage, Sarah Wayne Callies, Veronica Ferres ', 2, N'A professor frantically searches for his son who was abducted during a Halloween parade. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (15, N'War of the Worlds', 6, N'2017-11-12 00:00:00', N'2005-06-09 00:00:00', N'Tom Cruise, Dakota Fanning, Tim Robbins', 1, N'As Earth is invaded by alien tripod fighting machines, one family fights for survival. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (16, N'Original Sin', 10, N'2017-11-12 00:00:00', N'2001-10-11 00:00:00', N' Antonio Banderas, Angelina Jolie, Thomas Jane', 2, N'A woman along with her lover, plan to con a rich man by marrying him and on earning his trust running away with all his money. Everything goes as planned until she actually begins to fall in love with him.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (17, N'American Pie', 10, N'2017-11-12 00:00:00', N'1999-08-09 00:00:00', N' Jason Biggs, Chris Klein, Thomas Ian Nicholas', 2, N'Four teenage boys enter a pact to lose their virginity by prom night. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (18, N'Schindler''s List ', 9, N'2017-11-12 00:00:00', N'1993-02-04 00:00:00', N' Liam Neeson, Ralph Fiennes, Ben Kingsley', 1, N'In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazi Germans. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (19, N'12 Years a Slave', 9, N'2017-11-12 00:00:00', N'2013-01-12 00:00:00', N' Chiwetel Ejiofor, Michael Kenneth Williams, Michael Fassbender', 1, N'In the antebellum United States, Solomon Northup, a free black man from upstate New York, is abducted and sold into slavery.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (20, N'Titanic', 3, N'2017-11-12 00:00:00', N'1997-01-09 00:00:00', N' Leonardo DiCaprio, Kate Winslet, Billy Zane', 1, N'A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic. ')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (21, N'Me Before You', 3, N'2017-11-12 00:00:00', N'2016-06-03 00:00:00', N' Emilia Clarke, Sam Claflin, Janet McTeer', 2, N'A girl in a small town forms an unlikely bond with a recently-paralyzed man she''s taking care of.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (22, N'The Thing', 5, N'2017-11-12 00:00:00', N'2011-09-04 00:00:00', N'Mary Elizabeth Winstead, Joel Edgerton, Ulrich Thomsen', 1, N'At an Antarctica research site, the discovery of an alien craft leads to a confrontation between graduate student Kate Lloyd and scientist Dr. Sander Halvorson.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (23, N'The Ring', 5, N'2017-11-12 00:00:00', N'2002-02-07 00:00:00', N' Naomi Watts, Martin Henderson, Brian Cox', 1, N'A journalist must investigate a mysterious videotape which seems to cause the death of anyone in a week of viewing it.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (24, N'Up', 8, N'2017-11-12 00:00:00', N'2009-06-07 00:00:00', N' Edward Asner, Jordan Nagai, John Ratzenberger', 2, N'Seventy-eight year old Carl Fredricksen travels to Paradise Falls in his home equipped with balloons, inadvertently taking a young stowaway.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (25, N'Toy Story 3', 8, N'2017-11-12 00:00:00', N'2010-11-01 00:00:00', N' Tom Hanks, Tim Allen, Joan Cusack', 2, N'The toys are mistakenly delivered to a day-care center instead of the attic right before Andy leaves for college, and it''s up to Woody to convince the other toys that they weren''t abandoned and to return home.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (26, N'Moana', 7, N'2017-11-12 00:00:00', N'2016-12-08 00:00:00', N' Auli''i Cravalho, Dwayne Johnson, Rachel House', 1, N'In Ancient Polynesia, when a terrible curse incurred by the Demigod Maui reaches Moana''s island, she answers the Ocean''s call to seek out the Demigod to set things right.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (27, N'Despicable Me 3', 7, N'2017-11-12 00:00:00', N'2017-06-03 00:00:00', N'Steve Carell, Kristen Wiig, Trey Parker', 1, N'Gru meets his long-lost charming, cheerful, and more successful twin brother Dru who wants to team up with him for one last criminal heist.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (28, N'Wonder Woman', 12, N'2017-11-12 00:00:00', N'2017-06-01 00:00:00', N'Gal Gadot, Chris Pine, Robin Wright', 2, N'When a pilot crashes and tells of conflict in the outside world, Diana, an Amazonian warrior in training, leaves home to fight a war, discovering her full powers and true destiny.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (29, N'Kingsman: The Golden Circle', 12, N'2017-11-12 00:00:00', N'2017-09-12 00:00:00', N'Taron Egerton, Colin Firth, Mark Strong', 2, N'When their headquarters are destroyed and the world is held hostage, the Kingsman''s journey leads them to the discovery of an allied spy organization in the US. These two elite secret organizations must band together to defeat a common enemy.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (30, N'Thor: Ragnarok', 4, N'2017-11-12 00:00:00', N'2017-11-02 00:00:00', N'Chris Hemsworth, Tom Hiddleston, Cate Blanchett', 2, N'Imprisoned, the almighty Thor finds himself in a lethal gladiatorial contest against the Hulk, his former ally. Thor must fight for survival and race against time to prevent the all-powerful Hela from destroying his home and the Asgardian civilization.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (31, N'The Dark Knight', 4, N'2017-11-12 00:00:00', N'2008-08-04 00:00:00', N'Christian Bale, Heath Ledger, Aaron Eckhart', 1, N'When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham, the Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (32, N'A Bad Moms Christmas', 1, N'2017-11-12 00:00:00', N'2017-11-02 00:00:00', N'Mila Kunis, Kristen Bell, Kathryn Hahn', 2, N'As their own mothers drop in unexpectedly, our three under-appreciated and over-burdened moms rebel against the challenges and expectations of the Super Bowl for mothers: Christmas.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (33, N'Baywatch', 1, N'2017-11-12 00:00:00', N'2017-07-02 00:00:00', N'Dwayne Johnson, Zac Efron, Alexandra Daddario', 1, N'Devoted lifeguard Mitch Buchannon butts heads with a brash new recruit, as they uncover a criminal plot that threatens the future of the bay.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (34, N'La La Land', 2, N'2017-11-12 00:00:00', N'2016-12-08 00:00:00', N'Ryan Gosling, Emma Stone, Rosemarie DeWitt ', 1, N'While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.')
INSERT INTO [dbo].[Movies] ([ID], [movieName], [genreID], [dateAdded], [releaseDate], [actors], [membershipType], [summary]) VALUES (36, N'The Lord of the Rings: The Return of the King', 12, N'2017-11-12 00:00:00', N'2008-12-12 00:00:00', N'Elijah Wood, Viggo Mortensen, Ian McKellen', 1, N'Gandalf and Aragorn lead the World of Men against Sauron''s army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.')
SET IDENTITY_INSERT [dbo].[Movies] OFF

            ");

            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        rentalUser = c.String(),
                        rentalMovie = c.String(),
                        rentalExpiration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            Sql(@"SET IDENTITY_INSERT [dbo].[Rentals] ON
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (1, N'MicaArrowsmith@netfleeks.com', N'Gladiator', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (2, N'LoraineMcmaster@netfleeks.com', N'The Hangover', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (3, N'VelvaCollett@netfleeks.com', N'Scream', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (4, N'genishbat', N'the', N'2017-11-13 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (5, N'EthylMerryman@netfleeks.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (6, N'LoraineMcmaster@netfleeks.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (7, N'VelvaCollett@netfleeks.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (8, N'MarciaAble@netfleeks.com', N'Gladiator', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (9, N'KevinLeedy@netfleeks.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (14, N'AldoIacovelli@netfleeks.com', N'Frozen', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (15, N'HwaJosephson@netfleeks.com', N'Inception', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (19, N'DavidMace@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (20, N'LinneaVidaurri@netfleeks.com', N'Fifty Shades Darker', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (24, N'EthylMerryman@netfleeks.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (25, N'AldoIacovelli@netfleeks.com', N'Frozen', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (26, N'HwaJosephson@netfleeks.com', N'Inception', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (27, N'DavidMace@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (28, N'LinneaVidaurri@netfleeks.com', N'Fifty Shades Darker', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (29, N'KashaGallimore@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (30, N'JulietteBosh@netfleeks.com', N'Fifty Shades Darker', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (31, N'MarciaAble@netfleeks.com', N'Forrest Gump', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (32, N'MarciaAble@netfleeks.com', N'Forrest Gump', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (33, N'GemmaLinz@netfleeks.com', N'Scream', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (34, N'JosefinaRiebel@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (38, N'GemmaLinz@netfleeks.com', N'Scream', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (39, N'JosefinaRiebel@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (48, N'MicaArrowsmith@netfleeks.com', N'Fifty Shades Darker', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (49, N'DinorahDhillon@netfleeks.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (50, N'MicaArrowsmith@netfleeks.com', N'Fifty Shades Darker', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (51, N'DinorahDhillon@netfleeks.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (52, N'MicaArrowsmith@netfleeks.com', N'The Wolf of Wall Street', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (53, N'MicaArrowsmith@netfleeks.com', N'The Wolf of Wall Street', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (54, N'CorrieDau@netfleeks.com', N'The Notebook', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (55, N'CorrieDau@netfleeks.com', N'The Notebook', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (56, N'DavidMace@netfleeks.com', N'Scream', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (57, N'LinneaVidaurri@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (58, N'LoraineMcmaster@netfleeks.com', N'The Wolf of Wall Street', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (59, N'DinorahDhillon@netfleeks.com', N'The Hangover', N'2017-03-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (60, N'GemmaLinz@netfleeks.com', N'Inception', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (61, N'MicaArrowsmith@netfleeks.com', N'Gladiator', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (63, N'DavidMace@netfleeks.com', N'Scream', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (64, N'LinneaVidaurri@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (65, N'LoraineMcmaster@netfleeks.com', N'The Wolf of Wall Street', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (70, N'DinorahDhillon@netfleeks.com', N'The Hangover', N'2017-03-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (76, N'GemmaLinz@netfleeks.com', N'Inception', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (77, N'MicaArrowsmith@netfleeks.com', N'Gladiator', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (78, N'LoraineMcmaster@netfleeks.com', N'The Hangover', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (79, N'VelvaCollett@netfleeks.com', N'Scream', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (80, N'LoraineMcmaster@netfleeks.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (86, N'LoraineMcmaster@netfleeks.com', N'The Hangover', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (87, N'VelvaCollett@netfleeks.com', N'Scream', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (91, N'LoraineMcmaster@netfleeks.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (92, N'VelvaCollett@netfleeks.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (93, N'VelvaCollett@netfleeks.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (94, N'MarciaAble@netfleeks.com', N'Gladiator', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (95, N'KevinLeedy@netfleeks.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (96, N'MonserrateFabela@netfleeks.com', N'Scream', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (101, N'MarciaAble@netfleeks.com', N'Gladiator', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (102, N'KevinLeedy@netfleeks.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (103, N'MonserrateFabela@netfleeks.com', N'Scream', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (108, N'MonserrateFabela@netfleeks.com', N'Scream', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (109, N'GemmaLinz@netfleeks.com', N'Inception', N'2016-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (110, N'MicaArrowsmith@netfleeks.com', N'Gladiator', N'2016-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (111, N'DavidMace@netfleeks.com', N'Scream', N'2016-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (112, N'LinneaVidaurri@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (113, N'LoraineMcmaster@netfleeks.com', N'The Wolf of Wall Street', N'2015-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (114, N'DinorahDhillon@netfleeks.com', N'The Hangover', N'2015-03-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (115, N'GemmaLinz@netfleeks.com', N'Inception', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (116, N'MicaArrowsmith@netfleeks.com', N'Gladiator', N'2015-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (117, N'LoraineMcmaster@netfleeks.com', N'The Hangover', N'2015-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (118, N'VelvaCollett@netfleeks.com', N'Scream', N'2015-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (119, N'LoraineMcmaster@netfleeks.com', N'Frozen', N'2015-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (120, N'LoraineMcmaster@netfleeks.com', N'The Hangover', N'2015-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (121, N'VelvaCollett@netfleeks.com', N'Scream', N'2018-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (122, N'LoraineMcmaster@netfleeks.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (123, N'VelvaCollett@netfleeks.com', N'Inception', N'2016-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (124, N'VelvaCollett@netfleeks.com', N'Inception', N'2016-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (125, N'MarciaAble@netfleeks.com', N'Gladiator', N'2015-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (126, N'KevinLeedy@netfleeks.com', N'The Hangover', N'2016-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (127, N'MonserrateFabela@netfleeks.com', N'Scream', N'2016-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (128, N'MarciaAble@netfleeks.com', N'Gladiator', N'2016-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (129, N'KevinLeedy@netfleeks.com', N'The Hangover', N'2015-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (130, N'MonserrateFabela@netfleeks.com', N'Scream', N'2015-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (131, N'MonserrateFabela@netfleeks.com', N'Scream', N'2015-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (133, N'guest@netfleeks.com', N'Forrest Gump', N'2017-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (134, N'guest@netfleeks.com', N'The Notebook', N'2016-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (135, N'guest@netfleeks.com', N'Frozen', N'2016-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (136, N'guest@netfleeks.com', N'The Hangover', N'2017-11-20 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (137, N'guest@netfleeks.com', N'The Wolf of Wall Street', N'2017-11-28 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (138, N'guest@netfleeks.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalMovie], [rentalExpiration]) VALUES (139, N'guest@netfleeks.com', N'Inception', N'2017-11-10 00:00:00')
            SET IDENTITY_INSERT [dbo].[Rentals] OFF
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
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'002e0b7c-9b1f-4030-83d8-226bdccbcdc0', N'Loraine', N'Mcmaster', N'male', N'1993-07-06 00:00:00', 1, 1, N'LoraineMcmaster@netfleeks.com', 0, N'ADY9H1/ZgmtaYaq3EBQm3656pkhxBuJmZi0eEW5jz2xuQM8Gt/ycksVZQmGTP2rxkA==', N'280c037e-59d4-4365-92d3-58b411f55f08', NULL, 0, 0, NULL, 1, 0, N'LoraineMcmaster@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0944aae4-927e-4f46-b271-bc23eb8b986f', N'Lettie', N'Levitt', N'female', N'1991-07-01 00:00:00', 1, 2, N'LettieLevitt@netfleeks.com', 0, N'AE0a52DCfvECf89l9ubEBmnKLy8JhCiuB4f5alNn9l4la3avo5Qeck0fARb02Oz4fQ==', N'fe2419ea-6706-49f3-b646-66bc50fd866c', NULL, 0, 0, NULL, 1, 0, N'LettieLevitt@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c636a49-3991-4caf-b6c9-9cd378361891', N'Modesto', N'Tanksley', N'Female', N'1980-01-01 00:00:00', 1, 3, N'ModestoTanksley@netfleeks.com', 0, N'AGbL1XuXCA9KLdhDG9yk6boLdBlM1PgxElLinGh3SdEcnQhrMS8rgJx7C6rLYcIRdQ==', N'672c3f76-8493-40e7-8679-2ee936e7c955', NULL, 0, 0, NULL, 1, 0, N'ModestoTanksley@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'12f417ab-1e86-4642-8512-7650c40bada6', N'Brook', N'Middlebrooks', N'male', N'1991-03-01 00:00:00', 1, 4, N'BrookMiddlebrooks@netfleeks.com', 0, N'AOEFiDxBirXsvj1o8KQSN7MYhcIqDwSHaDndMc21rM7ETwQpwXqJpq3K0S4bogcmhw==', N'd984d5b6-cd69-498a-ad14-7b0a02a40f7e', NULL, 0, 0, NULL, 1, 0, N'BrookMiddlebrooks@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1b84aed6-d11e-4e13-9713-cc400a09407e', N'Merryman', N'Ethyl', N'Male', N'1991-11-05 00:00:00', 1, 5, N'EthylMerryman@netfleeks.com', 0, N'AF7UinowtRZTcpcJHyYZnMkse7KtLfpe5sFfTxo8hiAHYXIu9oNwXdagccjTwane6A==', N'9a7d209a-1c1b-4ab9-af46-c6815b2f7a5a', NULL, 0, 0, NULL, 1, 0, N'EthylMerryman@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2c80d8cf-9e46-4874-9f85-efafdad0bb39', N'Mica', N'Arrowsmith', N'female', N'1972-08-12 00:00:00', 2, 6, N'MicaArrowsmith@netfleeks.com', 0, N'ABdTPC/ig954qFL9gNTqrT9zSB8RNpUnmPZVAZ+eiFDR2LwCjn7HeWafU2bwHElqlw==', N'dc92b4ad-76bc-4128-ba47-e93b8e84f3c3', NULL, 0, 0, NULL, 1, 0, N'MicaArrowsmith@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'32ea37c3-c454-41e8-b657-0856ea908995', N'Hwa', N'Josephson', N'male', N'1980-07-05 00:00:00', 2, 7, N'HwaJosephson@netfleeks.com', 0, N'AIV46cTn0athyN3xdX6Nq/2OOmlIBE2pw+suZ+YsTXvdZJXEtWCBhZn/NyBhOlfU1A==', N'c734ba36-3066-4e67-82c7-3a49fa9eb12a', NULL, 0, 0, NULL, 1, 0, N'HwaJosephson@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3679ea23-fe40-4b28-8613-2d1db2aed345', N'Arlena', N'Admire', N'male', N'1966-08-07 00:00:00', 2, 8, N'ArlenaAdmire@netfleeks.com', 0, N'AN2SbiurQhEaVBoRs7pohrTm343eFhQnq+x9RLj85QdcjG9Zs36Mig3iNg0PAgtczA==', N'e61a750a-b3a0-4341-98c4-059976893880', NULL, 0, 0, NULL, 1, 0, N'ArlenaAdmire@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a660a27-c70b-40c3-a2a6-e340695680ab', N'Marcia', N'Able', N'Female', N'1969-07-02 00:00:00', 1, 9, N'MarciaAble@netfleeks.com', 0, N'ALpg/RXHLWKLRR5MmPOvNglPZfj0FAOz4D18yhQrLZ/VrfPBlbgfhPJV99XAGYMLDw==', N'a35aca51-a5c3-4714-9835-eb7caf3e86ba', NULL, 0, 0, NULL, 1, 0, N'MarciaAble@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45715a90-af82-45b9-9ba9-6c6a1cd797c8', N'Fabela', N'Monserrate', N'female', N'1970-07-12 00:00:00', 1, 10, N'MonserrateFabela@netfleeks.com', 0, N'APZY7Dhit58b+cUg6mNDPn2m/o2vT86mUcO+OKOE9mmlhzotmAp3YvoEZPyIDDhtqA==', N'8c99b07a-ed2f-4cb1-835e-b17699cc9e55', NULL, 0, 0, NULL, 1, 0, N'MonserrateFabela@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4deb911c-5f3f-4534-9103-c43f0f802a6c', N'Melanie', N'Gates', N'Female', N'1991-02-02 00:00:00', 1, 11, N'MelanieGates@netfleeks.com', 0, N'AGQLZXIpAB3/urxyDSmV+CJk4LdJTEcTRue2dKBdP5/ihqhQea6D0RSksp+Hbvx6DQ==', N'b8254c50-4b9f-45bd-b03d-21cfec4ef436', NULL, 0, 0, NULL, 1, 0, N'MelanieGates@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54174d90-0650-47ba-a0c8-b8881a48063f', N'Corrie', N'Dau', N'male', N'1990-01-01 00:00:00', 2, 12, N'CorrieDau@netfleeks.com', 0, N'AFJbrXBGwcX48+jRgbA5w0p1DbYjVpb0UGmVi/2TjTsSalx4BNDV2lVsjxclBwjMMg==', N'2935066a-8912-419d-89e6-70fac8e5c856', NULL, 0, 0, NULL, 1, 0, N'CorrieDau@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5d8757d4-fe5a-4ca1-a010-6e0da2397c0d', N'Linnea', N'Vidaurri', N'male', N'1991-07-11 00:00:00', 2, 1, N'LinneaVidaurri@netfleeks.com', 0, N'AIRocUDKWpYwvbk2zCMgLKkoJb2Xs/d6y9gMxl47oYjmN/xOzE3UB7bDT5cO2uff/g==', N'21454798-fb10-4a3f-bc8c-4b47af43d419', NULL, 0, 0, NULL, 1, 0, N'LinneaVidaurri@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'637d7611-ca44-4e51-ae6c-8e85cc8c947b', N'David', N'Mace', N'male', N'1988-07-05 00:00:00', 2, 2, N'DavidMace@netfleeks.com', 0, N'AGbuTP2OEb1d8B2mkaUr1DwnuaJw6l/LKGgKUA00jnBrMD267cKhELDKFujZLAtymQ==', N'fbd26175-4bc6-4ff6-a6af-aff961179dcc', NULL, 0, 0, NULL, 1, 0, N'DavidMace@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'658a1fd0-7527-4bc1-80ac-047be66a4593', N'Dhillon', N'Dinorah', N'male', N'1991-01-08 00:00:00', 1, 3, N'DinorahDhillon@netfleeks.com', 0, N'AJqWWCF+2LI4Fo+LNNVzkhC/hw9JHGhTs1zQpfDXqBijoYMEm06+YiuU74ywUhzSNg==', N'f51fc8cd-0a2e-4f16-8ad5-86b33de8c73d', NULL, 0, 0, NULL, 1, 0, N'DinorahDhillon@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6dc30dce-0a15-4596-99e0-f0b58ff06490', N'Linz', N'Gemma', N'Female', N'1964-03-11 00:00:00', 1, 4, N'GemmaLinz@netfleeks.com', 0, N'AMcu/IvAVBjP8u3OAXsUgziDdI/eflH/Q97ULEs1r+q3OGPqWOqcdtAIL4SuMibJEQ==', N'deaa5899-9abc-485c-8aa4-e58c931f0b85', NULL, 0, 0, NULL, 1, 0, N'GemmaLinz@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90de9e1c-8eae-4642-8918-a52c6fcff28d', N'Admin', N'Admin', N'Female', N'1990-01-01 00:00:00', 1, 5, N'admin@netfleeks.com', 0, N'APgc8All1us+lIB0rYpQj1dsvfmmjPL/NY/o823wNfTq57VlhFQEbilFZd7h1B0HcQ==', N'611e7412-723e-437b-889a-d9456af8a9a6', NULL, 0, 0, NULL, 1, 0, N'admin@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'927d2c14-c082-454a-8e93-ced88d93cba5', N'Louie', N'Fulmer', N'male', N'1982-11-10 00:00:00', 1, 1, N'LouieFulmer@netfleeks.com', 0, N'ACqthdy5mgkiC04HerXs7MntGoiB2/esDU76oDy7TX4QROuG44oNzKUQv3aO2lv6Pw==', N'0e8e2a04-7db7-4815-b9f3-778afd222c7a', NULL, 0, 0, NULL, 1, 0, N'LouieFulmer@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b39e5ae4-6ad3-401d-a607-c908cd76e099', N'Kevin', N'Leedy', N'male', N'1982-10-12 00:00:00', 1, 2, N'KevinLeedy@netfleeks.com', 0, N'APgnN1iKwjU4VmWD3nakkhXT/XkQAzI9n4Jss4n4pZw7Ntp6oSa7r8lNE0Z8i7mw2A==', N'080fb082-3155-4285-8840-6ef912cd8631', NULL, 0, 0, NULL, 1, 0, N'KevinLeedy@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7df5533-177d-4cf0-a898-225207ccebe2', N'Kasha', N'Gallimore', N'male', N'1995-06-06 00:00:00', 1, 3, N'KashaGallimore@netfleeks.com', 0, N'AH6MHNDP58Uy7KN4Tzhl7GfIXtX3oITfAAlYNt4AN9RWo1fJQom+sY3u1SZxFVPHrA==', N'd9611769-ab63-4e0b-b971-be1e7f3665e0', NULL, 0, 0, NULL, 1, 0, N'KashaGallimore@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c06e2d4c-f7b9-4c5c-84c5-f73fd97f513d', N'Kris', N'Swarthout', N'male', N'1983-03-12 00:00:00', 2, 1, N'KrisSwarthout@netfleeks.com', 0, N'AAkfrVYbMCEKvvUKvggzIs+cicXUQ84l1NPQDqgDmClWYNNJhYlbLHmqfhYgskAaWw==', N'0a942ecb-1bac-40a2-9db8-d7736c755f52', NULL, 0, 0, NULL, 1, 0, N'KrisSwarthout@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c34f18fc-6b9c-41f5-9d00-e1abb46931ad', N'guest', N'guest', N'female', N'1990-01-01 00:00:00', 2, 2, N'guest@netfleeks.com', 0, N'AHUFfH4vQX75vmLlumICDSGkeYlytv932CqS7/8DcCkv22SqhJd7X039CbNe2FCKUg==', N'291ebe6d-2771-4631-9e9d-d20e4ed0addf', NULL, 0, 0, NULL, 1, 0, N'guest@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c3dba52c-7937-4df3-9a07-93215dca3e9c', N'Josefina', N'Riebel', N'Female', N'1980-06-04 00:00:00', 1, 3, N'JosefinaRiebel@netfleeks.com', 0, N'AHfPXQa/TylmS/XS8d4TGsZhvjXe1MueMQMJDN4Z6gAhikL1Sf163FELTDfUhBamkA==', N'ed48e42b-2ede-4d77-84de-0bc31e7d8faf', NULL, 0, 0, NULL, 1, 0, N'JosefinaRiebel@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2f68248-e93c-43d0-ab6b-aa43ad0a6fd2', N'Aldo', N'Iacovelli', N'female', N'1979-02-05 00:00:00', 2, 1, N'AldoIacovelli@netfleeks.com', 0, N'AAvBDW04zc21d6hUN4k1rNrS7CsOPyNpM51SjnBPTaxY7fWaCoifCQWKh1eneDD2BA==', N'8b5bb30b-d2e7-4412-9edd-79a45785567f', NULL, 0, 0, NULL, 1, 0, N'AldoIacovelli@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd63db566-c9e1-4e88-859c-2569ae652564', N'Chantay', N'Blackwater', N'male', N'1984-07-07 00:00:00', 1, 1, N'ChantayBlackwater@netfleeks.com', 0, N'ALaKBaANNO4Q+YuSn5uYqhkPpeshmwwmT2DlvQMr8DmWilqXlF93WdjKmckPrRYadw==', N'bcb4bca7-576d-4bd8-8e0c-99f275e36b81', NULL, 0, 0, NULL, 1, 0, N'ChantayBlackwater@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dafa9647-2ab1-49d4-8438-21e50a3b717b', N'Clint', N'Nero', N'male', N'1980-12-02 00:00:00', 2, 8, N'ClintNero@netfleeks.com', 0, N'ALVqTDboGYI4gJs5eqZXY1gv1Q2C0NDpk2JIVlSeZS8k7zNFgEKb3T6a5vpZ6DLQVQ==', N'1138dfed-5b93-4361-a527-e2a4cb4fb1ef', NULL, 0, 0, NULL, 1, 0, N'ClintNero@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc8072de-4f6b-41f0-bfb3-6a9d6e899cb8', N'Chrystal', N'Kari', N'male', N'1996-03-05 00:00:00', 1, 9, N'ChrystalKari@netfleeks.com', 0, N'AP/OPnuc4DZ9bYqEm43hF+TxYtXb85+GEtKT65Q3otG+yRkmMguDixskMsTEK9Q/BQ==', N'62214218-f8f2-406e-a4a0-be327ea5a8d6', NULL, 0, 0, NULL, 1, 0, N'ChrystalKari@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd005e61-674c-41af-8b18-f87bf3d6fe06', N'Yolanda', N'Rylander', N'female', N'1996-06-04 00:00:00', 2, 10, N'YolandaRylander@netfleeks.com', 0, N'AFaEYdnWGquVTJ2/l5Pmm/EaN2umvZteipOoFNyLrgCk8y7fjmcqn4enmcl3kO54RQ==', N'a65dc6da-6798-4d16-b028-2c7fdd658824', NULL, 0, 0, NULL, 1, 0, N'YolandaRylander@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea32605b-0005-4d72-911f-a7362670f205', N'Louetta', N'Lachapelle', N'male', N'1969-04-12 00:00:00', 2, 12, N'LouettaLachapelle@netfleeks.com', 0, N'AKpFB71buRivWB009sc+/Bq+rG124Fw21g0E34GYYQTHppZV1JstJVhuOOWBBLug7g==', N'4c765c0f-a885-4c97-a4d9-e4fc56bd0ae9', NULL, 0, 0, NULL, 1, 0, N'LouettaLachapelle@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eaf4776d-f0a9-4abd-bf12-013a235d8a97', N'Jaleesa', N'Polite', N'female', N'1987-01-04 00:00:00', 2, 11, N'JaleesaPolite@netfleeks.com', 0, N'AOre78uSQ44jhnsPoLvbGlkn8LhgLLiaO3dBrbyUCncEK5DEgffc4kJFNDbjffBoQQ==', N'15be2794-2545-4cfe-b195-2126966a022c', NULL, 0, 0, NULL, 1, 0, N'JaleesaPolite@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3e8f596-67b2-45d6-8efd-2d3f3824642b', N'Juliette', N'Bosh', N'female', N'1993-05-09 00:00:00', 2, 1, N'JulietteBosh@netfleeks.com', 0, N'ACg7qOeq0vnxrpOslBPwFSLWhwIE/LJzupEpKhAUnS1DLiygCO1kctVAnn+kuIQvLQ==', N'2d250bb9-46e5-4053-8dc3-ece599f21fc5', NULL, 0, 0, NULL, 1, 0, N'JulietteBosh@netfleeks.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ff774146-cf5c-453a-b17d-48965e43b28c', N'Velva', N'Collett', N'female', N'1996-02-12 00:00:00', 2, 3, N'VelvaCollett@netfleeks.com', 0, N'AJaD5JhFyS+m1xtA5ArIg59jyJ7NDP9D2nCmTqFfqMmpb1XkmGfk1LfRFH0LdJQBQA==', N'86c11ffb-2e9a-440c-adb2-cc50c5d64820', NULL, 0, 0, NULL, 1, 0, N'VelvaCollett@netfleeks.com')
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
            DropForeignKey("dbo.Movies", "genreID", "dbo.Genres");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
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
            DropTable("dbo.Cinemas");
        }
    }
}
