using ComicApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(BookContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Collections.Any())
            {
                var collections = new Collection[]
                {
                new Collection{ Name = "DC", CreationDate = DateTime.Parse("2003-09-01") },
                new Collection{ Name = "Marvel", CreationDate = DateTime.Parse("2005-09-01") },
                };

                foreach (Collection s in collections)
                {
                    context.Collections.Add(s);
                }

                context.SaveChanges();

            }

            if (!context.Comics.Any())
            {
                var comics = new Comic[]
                {
                new Comic{Name = "Batman", CreationDate = DateTime.Parse("2002-09-01"), CollectionId = 1},
                new Comic{Name = "Spider-Man", CreationDate = DateTime.Parse("2003-09-01"), CollectionId = 2},
                new Comic{Name = "Superman", CreationDate = DateTime.Parse("2005-09-01"), CollectionId = 1},
                };

                foreach (Comic s in comics)
                {
                    context.Comics.Add(s);
                }

                context.SaveChanges();

            }

        }
    }
}
