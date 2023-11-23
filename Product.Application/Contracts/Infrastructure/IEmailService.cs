using Product.Application.Models;
using System.Threading.Tasks;

namespace Product.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
