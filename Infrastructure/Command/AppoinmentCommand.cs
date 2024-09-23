using Hospitalpage.Models;
using MediatR;

namespace Hospitalpage.Infrastructure.Command
{
    public record CretaeAppoinmentCommand(Appoinment value) :IRequest<string>;
}
