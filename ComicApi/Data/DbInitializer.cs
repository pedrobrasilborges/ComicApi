using ComicApi.Models;
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

            // Look for any students.
            if (context.Comics.Any())
            {
                return;   // DB has been seeded
            }

            var comics = new Comic[]
            {
            new Comic{Name = "Batman", CreationDate = DateTime.Parse("2002-09-01")},
            new Comic{Name = "Spider-Man", CreationDate = DateTime.Parse("2003-09-01")},
            new Comic{Name = "Superman", CreationDate = DateTime.Parse("2005-09-01")},
            };
            foreach (Comic s in comics)
            {
                context.Comics.Add(s);
            }
            context.SaveChanges();
        }
    }
}
