using Hospitalpage.Infrastructure.Command;
using Hospitalpage.Infrastructure.Contract;
using Hospitalpage.Infrastructure.Query;
using Hospitalpage.Infrastructure.Response;
using MediatR;

namespace Hospitalpage.Infrastructure.Handler
{
    public class CreateAppoinmentHandler:IRequestHandler<CretaeAppoinmentCommand,string>
    {
        private readonly IAppoinment _appoinment;
        public CreateAppoinmentHandler(IAppoinment appoinment)
        {
            _appoinment = appoinment;
        }
        public async Task<string> Handle(CretaeAppoinmentCommand command,CancellationToken cancellationToken)
        {
            var resp = await _appoinment.createAppoinmentAsync(command.value);
            return resp;
        }
    }
    public class GetAppoinmentHandler : IRequestHandler<GetAppoinmentQuery, IEnumerable<AppoinmentResponse>>
    {
        private readonly IAppoinment _appoinment;
        public GetAppoinmentHandler(IAppoinment appoinment)
        {
            _appoinment = appoinment;
        }
        public async Task<IEnumerable<AppoinmentResponse>> Handle(GetAppoinmentQuery command, CancellationToken cancellationToken)
        {
            var resp = await _appoinment.GetAllAppoinmentAsync();
            return resp;
        }
    }
}
