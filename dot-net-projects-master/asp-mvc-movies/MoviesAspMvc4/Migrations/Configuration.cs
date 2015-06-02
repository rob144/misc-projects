namespace MoviesAspMvc4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    //using System.Linq;
    using MoviesAspMvc4.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesAspMvc4.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoviesAspMvc4.Models.MovieDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Movies.AddOrUpdate(i => i.Title,
                new Movie
                {
                    Title = "Gladiator",
                    ReleaseDate = DateTime.Parse("05/05/2000"),
                    Genre = "Action",
                    Price = 5.00M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Back To The Future",
                    ReleaseDate = DateTime.Parse("03/07/1985"),
                    Genre = "Sci-Fi",
                    Price = 3.00M,
                    Rating = "PG"
                },

                new Movie
                {
                    Title = "The Hobbit: An Unexpected Journey",
                    ReleaseDate = DateTime.Parse("14/12/2012"),
                    Genre = "Fantasy",
                    Price = 12.00M,
                    Rating = "PG-13"
                },

                new Movie
                {
                    Title = "The Dark Knight",
                    ReleaseDate = DateTime.Parse("18/07/2008"),
                    Genre = "Crime",
                    Price = 6.00M,
                    Rating = "PG-13"
                },

                new Movie
                {
                    Title = "Inception",
                    ReleaseDate = DateTime.Parse("16/07/2010"),
                    Genre = "Mystery",
                    Price = 8.00M,
                    Rating = "PG-13"
                }
           );
        }
    }
}
