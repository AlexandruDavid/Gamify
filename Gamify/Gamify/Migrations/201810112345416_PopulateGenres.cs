namespace Gamify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action-Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Casual')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Idle')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Indie')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Role-Playing')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Simulation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Strategy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Sports')");
        }
        
        public override void Down()
        {
        }
    }
}
