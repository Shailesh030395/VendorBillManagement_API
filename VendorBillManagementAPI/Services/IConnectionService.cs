using System.Threading.Tasks;

namespace QuickBooksIntegration.Services
{
    public interface IConnectionService
    {
        Task SaveQuickBooksAuthDetails(string accessToken, string refreshToken, string realmId);
    }
}
