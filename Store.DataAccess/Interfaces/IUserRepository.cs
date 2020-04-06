using System;
using System.Threading.Tasks;
using Store.DataAccess.DataModels;

namespace Store.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с пользователями
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Получить пользователя по email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetByEmailAsync( string email );

        /// <summary>
        /// Добавить временного пользователя
        /// </summary>
        /// <param name="userId">Id временного пользователя</param>
        Task InsertTemporaryUser( User user );
    }
}