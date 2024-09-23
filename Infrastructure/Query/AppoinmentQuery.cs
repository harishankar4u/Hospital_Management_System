using Hospitalpage.Infrastructure.Response;
using Hospitalpage.Models;
using MediatR;

namespace Hospitalpage.Infrastructure.Query
{
    public record GetAppoinmentQuery() : IRequest<IEnumerable<AppoinmentResponse>>;
}
