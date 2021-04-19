using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicApi.Data.Entities
{
    public class Comic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}
