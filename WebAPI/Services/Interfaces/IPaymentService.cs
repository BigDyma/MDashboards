using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IPaymentService
    {
        Task CreateCharge(string token, int amount);
    }
}