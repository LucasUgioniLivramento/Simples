using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
