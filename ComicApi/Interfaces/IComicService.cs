using ComicApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ComicApi.Interfaces
{
    public interface IComicService
    {
        Task<GetComicListResponseDto> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    }
}
