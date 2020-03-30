using System.Threading.Tasks;
using Store.DataAccess.DataModels;

namespace Store.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync( string email );
    }
}