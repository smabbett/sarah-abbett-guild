namespace DvdLibrary.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLibrary.Models.DvdLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdLibrary.Models.DvdLibraryEntities context)
        {
            context.Dvds.AddOrUpdate(
             d => d.Title,
             new Dvd
             {
                 Title = "Ghost",
                 ReleaseYear = 1990,
                 Director = "Jerry Zucker",
                 Rating = "PG-13",
                 Notes = "After a young man is murdered, his spirit stays behind to warn his lover of impending danger, with the help of a reluctant psychic."
             },
              new Dvd
              {
                  Title = "Freaky Friday",
                  ReleaseYear = 2003,
                  Director = "Mark Waters",
                  Rating = "PG",
                  Notes = "An overworked mother and her daughter do not get along. When they switch bodies, each is forced to adapt to the other's life for one freaky Friday."
              },
               new Dvd
               {
                   Title = "The Notebook",
                   ReleaseYear = 2004,
                   Director = "Nick Cassavetes",
                   Rating = "PG-13",
                   Notes = "A poor yet passionate young man falls in love with a rich young woman, giving her a sense of freedom, but they are soon separated because of their social differences.."
               },
               new Dvd
               {
                   Title = "My Sister's Keeper",
                   ReleaseYear = 2009,
                   Director = "Nick Cassavetes",
                   Rating = "PG-13",
                   Notes = "Anna Fitzgerald looks to earn medical emancipation from her parents who until now have relied on their youngest child to help their leukemia-stricken daughter Kate remain alive."
               }
         );     
        }
    }
}
