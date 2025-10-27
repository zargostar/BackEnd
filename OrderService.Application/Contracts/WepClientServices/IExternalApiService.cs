using OrderService.Application.Features.Genres.Queries.Getgenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Contracts.WepClientServices
{
    public interface IExternalApiService
    {
        Task<List<GenreDto>> SaveExternalGenre(List<int> ids, CancellationToken cancellationToken);
    }
}
