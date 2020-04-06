using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Account;
using Store.DataAccess.DataModels;

namespace Store.BusinessLogic.Services.Account
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Проверка, был ли пользователь зарегистрирован ранее
        /// </summary>
        /// <param name="email">Проверяемый email</param>
        Task<bool> IsUserSignUpAsync( string email );

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model">Информация о пользователе</param>
        Task SignUpAsync( SignUpModel model );

        /// <summary>
        /// Валидация данных регистрируемого пользователя
        /// </summary>
        /// <param name="email">email пользователя</param>
        /// <param name="password">пароль пользователя</param>
        Task<(bool isSuccess, Dictionary<string, string> errors)> ValidateAsync( string email, string password );

        /// <summary>
        /// Получить пользователя по email 
        /// </summary>
        /// <param name="email">email пользователя</param>
        Task<User> GetUserAsync( string email );

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        Task<User> GetUserAsync( Guid id );

        /// <summary>
        /// Вернуть информацию о пользователе для профиля
        /// </summary>
        /// <param name="userId"></param>
        Task<UserExtendedInfoModel> GetUserExtendedInfoAsync( Guid userId );

        /// <summary>
        /// Вернуть короткое имя пользователя
        /// </summary>
        /// <param name="id"></param>
        Task<string> GetShortNameAsync( Guid id );

        /// <summary>
        /// Создание временного пользователя
        /// </summary>
        /// <remarks>
        /// Необходимо тогда, когда пользователь
        /// либо не зарегистрирован
        /// либо не авторизован
        /// </remarks>
        /// <param name="userId"></param>
        Task CreateTemporaryAccountAsync( Guid userId );

        /// <summary>
        /// Проверка, временный это пользователь или нет
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        Task<bool> IsTemporaryUserAsync( Guid userId );

        /// <summary>
        /// Активация временного аккаунта
        /// </summary>
        /// <param name="model">Данные пользователя</param>
        /// <returns></returns>
        Task ActivateTemporaryAccountAsync( SignUpModel model );

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        Task DeleteUserAsync( Guid userId );

        /// <summary>
        /// Обновить информацию о пользователе
        /// </summary>
        /// <param name="model">Информация о пользователе</param>
        /// <returns></returns>
        Task UpdateAccountAsync( AccountModel model );
    }
}