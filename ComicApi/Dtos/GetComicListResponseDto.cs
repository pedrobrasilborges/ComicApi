using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicApi.Dtos
{
    public record GetComicListResponseDto
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<GetComicResponseDto> Items { get; init; }
    }
}
