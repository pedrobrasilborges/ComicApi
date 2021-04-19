using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicApi.Data;
using Microsoft.AspNetCore.Authorization;
using ComicApi.Data.Entities;
using ComicApi.Dtos;
using System.Threading;
using ComicApi.Interfaces;
using System.Net;
using ComicApi.Models;
using ComicApi.Extensions;

namespace ComicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly BookContext _context;
        private readonly IComicService _service;

        public ComicsController(BookContext context, IComicService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Comics
        [HttpGet(Name=nameof(GetComicsAsync))]
        [ProducesResponseType(typeof(GetComicListResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetComicsAsync(
            [FromQuery] UrlQueryParameters urlQueryParameters,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var hobbies = await _service.GetByPageAsync(
                                    urlQueryParameters.Limit,
                                    urlQueryParameters.Page,
                                    cancellationToken);

            return Ok(GeneratePageLinks(urlQueryParameters, hobbies));
        }

        // GET: api/Comics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comic>> GetComic(int id)
        {
            var comic = await _context.Comics.FindAsync(id);

            if (comic == null)
            {
                return NotFound();
            }

            return comic;
        }

        private GetComicListResponseDto GeneratePageLinks(UrlQueryParameters queryParameters,
                    GetComicListResponseDto response)
        {
            if (response.CurrentPage > 1)
            {
                var prevRoute = Url.RouteUrl(nameof(GetComicsAsync), new { limit = queryParameters.Limit, page = queryParameters.Page - 1 });

                response.AddResourceLink(LinkedResourceType.Prev, prevRoute);
            }

            if (response.CurrentPage < response.TotalPages)
            {
                var nextRoute = Url.RouteUrl(nameof(GetComicsAsync), new { limit = queryParameters.Limit, page = queryParameters.Page + 1 });

                response.AddResourceLink(LinkedResourceType.Next, nextRoute);
            }

            return response;
        }
    }

    public record UrlQueryParameters(int Limit = 50, int Page = 1);

   
}
