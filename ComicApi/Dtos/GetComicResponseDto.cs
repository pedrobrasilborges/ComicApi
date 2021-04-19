using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicApi.Dtos
{
    public record GetComicResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime CreationDate { get; init; }
    }
}
