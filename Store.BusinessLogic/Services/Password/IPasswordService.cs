namespace Store.BusinessLogic.Services.Password
{
    /// <summary>
    /// Сервис для шифрования паролей пользователей
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Вернуть хеш пароля
        /// </summary>
        /// <param name="password">Пароль для хеширования</param>
        /// <returns></returns>
        string GetHash( string password );

        /// <summary>
        /// Проверка, что пароль совпадает с хешированной версией
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashed"></param>
        /// <returns></returns>
        bool ValidateHash( string password, string hashed );
    }
}