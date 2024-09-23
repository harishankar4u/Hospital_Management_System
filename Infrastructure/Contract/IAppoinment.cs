using Hospitalpage.Infrastructure.Response;
using Hospitalpage.Models;

namespace Hospitalpage.Infrastructure.Contract
{
    public interface IAppoinment
    {
        Task<string> createAppoinmentAsync(Appoinment value);
        Task<IEnumerable<AppoinmentResponse>> GetAllAppoinmentAsync();
        Task<AppoinmentResponse> GetAppoinmentAsync(int id);
    }
}
