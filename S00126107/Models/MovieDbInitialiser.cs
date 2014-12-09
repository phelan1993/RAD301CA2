using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public class MovieDbInitialiser : DropCreateDatabaseAlways<MoviesDb>
    {
        protected override void Seed(MoviesDb context)
        {
            #region Seed Actors
            var actors = new List<Actor>()
            {
            new Actor()
            {
            FirstName = "Colin", LastName = "Farrell", Gender = Gender.Male,
            BirthPlace = "Ireland", DateOfBirth = DateTime.Parse("31/05/1976"), ImageUrl = "http://goo.gl/WIc5sA"
            },
            new Actor()
            {
            FirstName = "Brendan", LastName = "Gleeson", Gender = Gender.Male,
            BirthPlace = "Ireland", DateOfBirth = DateTime.Parse("29/03/1955"), ImageUrl = "http://goo.gl/k10bvV"
            }, 
            new Actor()
            {
            FirstName = "Jennifer", LastName = "Aniston", Gender = Gender.Female,
            BirthPlace = "USA", DateOfBirth = DateTime.Parse("11/02/1969"), ImageUrl = "http://goo.gl/uMNFui"
            },
            new Actor()
            {
            FirstName = "Morgan", LastName = "Freeman", Gender = Gender.Male,
            BirthPlace = "USA", DateOfBirth = DateTime.Parse("01/06/1937"), ImageUrl = "http://goo.gl/G5tYmF"
            },
            new Actor()
            {
            FirstName = "Andrew", LastName = "Garfield", Gender = Gender.Male,
            BirthPlace = "USA", DateOfBirth = DateTime.Parse("20/09/1983"), ImageUrl = "http://goo.gl/8FN0Co"
            },
            new Actor()
            {
            FirstName = "Pierce", LastName = "Brosnan", Gender = Gender.Male,
            BirthPlace = "Ireland", DateOfBirth = DateTime.Parse("16/05/1953"), ImageUrl = "http://goo.gl/1lUkTf"
            },
            new Actor
            {
            FirstName = "John", LastName = "Travolta", Gender = Gender.Male,
            BirthPlace = "USA", DateOfBirth = DateTime.Parse("18/02/1954"), ImageUrl = "http://goo.gl/9ASBKZ"
            },
            new Actor()
            {
            FirstName = "Samuel L.", LastName = "Jackson", Gender = Gender.Male,
            BirthPlace = "USA", DateOfBirth = DateTime.Parse("21/12/1948"), ImageUrl = "http://goo.gl/jOSR9Z"
            },
            new Actor()
            {
            FirstName = "Jamie", LastName = "Foxx", Gender = Gender.Male,
            BirthPlace = "USA", DateOfBirth = DateTime.Parse("13/12/1967"), ImageUrl = "http://goo.gl/6g6pJq"
            },
            new Actor()
            {
            FirstName = "Emma", LastName = "Stone", Gender = Gender.Female,
            BirthPlace = "USA", DateOfBirth = DateTime.Parse("06/11/1988"), ImageUrl = "http://goo.gl/9oMmx2"
            }
            };
            actors.ForEach(actor => context.Actors.Add(actor));
            context.SaveChanges();
            #endregion
            #region Seed Movies
            var movies = new List<Movie>()
            {
            new Movie()
            {
            Title = "In Bruges", ReleaseDate = DateTime.Parse("07/03/2008"), Genre = new Genre()
            {
                Title = "Crime-Comedy"
            },
            Rating = 8, Certificate = Certificate.Sixteen, Runtime = 107, Language = Language.English, 
            ImageUrl = "http://goo.gl/Ll1Eui", Description = "Guilt-stricken after a job gone wrong, hitman Ray and his partner await orders from their ruthless boss in Bruges, Belgium, the last place in the world Ray wants to be."
            },
            new Movie()
            {
            Title = "Top Gun", ReleaseDate = DateTime.Parse("16/05/1986"), Genre = new Genre()
            {
                Title = "Comedy"
            },
            Rating = 7, Certificate = Certificate.Pg, Runtime = 110, Language = Language.English, ImageUrl = "http://goo.gl/gT1EMZ"
            },
            new Movie()
            {
            Title = "Monty Python and the Holy Grail", ReleaseDate = DateTime.Parse("23/05/1975"),  Genre = new Genre()
            {
                Title = "Adventure"
            },
            Rating = 8, Certificate = Certificate.Pg, Runtime = 91, Language = Language.English, ImageUrl = "http://goo.gl/AMdvIk"
            },
            new Movie()
            {
            Title = "The Shawshank Redemption", ReleaseDate = DateTime.Parse("14/10/1994"), Genre = new Genre()
            {
                Title = "Drama"
            },
            Rating = 9, Certificate = Certificate.Eighteen, Runtime = 142, Language = Language.English, ImageUrl = "http://goo.gl/zIu6cE"
            },
            new Movie()
            {
            Title = "The Dark Knight Rises", ReleaseDate = DateTime.Parse("20/07/2012"), Genre = new Genre()
            {
                Title = "Action-Adventure"
            },
            Rating = 9, Certificate = Certificate.TwelveA, Runtime = 165, Language = Language.English, ImageUrl = "http://goo.gl/SiUZwo"
            }
            };
            movies.ForEach(movie => context.Movies.Add(movie));
            context.SaveChanges();
            #endregion
            #region Seed Casts

            var casts = new List<MovieCast>()
            {
                new MovieCast()
                {
                    MovieId = 1,
                    ActorId = 1,
                    ScreenName = "Ray"
                },
                new MovieCast()
                {
                    MovieId = 1,
                    ActorId = 2,
                    ScreenName = "Ken"
                },
                new MovieCast()
                {
                    MovieId = 4,
                    ActorId = 4,
                    ScreenName = "Red"
                },
                new MovieCast()
                {
                    MovieId = 5,
                    ActorId = 4,
                    ScreenName = "Lucius Fox"
                }
                
            };
            casts.ForEach(cast => context.Casts.Add(cast));
            context.SaveChanges();

            #endregion

        }
    }
}