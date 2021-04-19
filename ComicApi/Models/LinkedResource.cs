using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicApi.Models
{
    public record LinkedResource(string href);

    public enum LinkedResourceType
    {
        None,
        Prev,
        Next
    }
}
