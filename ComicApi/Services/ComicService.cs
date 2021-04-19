using ComicApi.Data;
using ComicApi.Dtos;
using ComicApi.Extensions;
using ComicApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ComicApi.Services
{
    public class ComicService : IComicService
    {
        private readonly BookContext _dbContext;
        public ComicService(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetComicListResponseDto> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
        {

            var hobbies = await _dbContext.Comics
                           .AsNoTracking()
                           .OrderBy(p => p.CreationDate)
                           .PaginateAsync(page, limit, cancellationToken);

            return new GetComicListResponseDto
            {
                CurrentPage = hobbies.CurrentPage,
                TotalPages = hobbies.TotalPages,
                TotalItems = hobbies.TotalItems,
                Items = hobbies.Items.Select(p => new GetComicResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreationDate = p.CreationDate
                }).ToList()
            };
        }
    }
}
