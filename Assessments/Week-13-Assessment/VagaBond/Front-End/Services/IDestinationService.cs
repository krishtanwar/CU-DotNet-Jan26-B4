using Front_End.Models;
using Microsoft.Build.Utilities;
namespace Front_End.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
    }
}
