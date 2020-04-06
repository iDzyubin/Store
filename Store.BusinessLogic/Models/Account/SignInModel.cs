using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.Account
{
    /// <summary>
    /// Модель для авторизации
    /// </summary>
    public class SignInModel
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required( ErrorMessage = "Не указан Email" )]
        [DataType( DataType.EmailAddress )]
        public string Email { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        [Required( ErrorMessage = "Не указан пароль" )]
        [DataType( DataType.Password )]
        public string Password { get; set; }
    }
}