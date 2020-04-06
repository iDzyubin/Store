using System;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.Account
{
    /// <summary>
    /// Модель для регистрации пользователя
    /// </summary>
    public class SignUpModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        [Required( ErrorMessage = "Не указан Email" )]
        [EmailAddress( ErrorMessage = "Недействительный e-mail адрес" )]
        public string Email { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        [Required( ErrorMessage = "Не указано имя" )]
        [MaxLength( 50, ErrorMessage = "Длина имени не может превышать {1} символов" )]
        public string FirstName { get; set; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required( ErrorMessage = "Не указана фамилия" )]
        [MaxLength( 50, ErrorMessage = "Длина фамилии не может превышать {1} символов" )]
        public string LastName { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        [Required( ErrorMessage = "Не указан пароль" )]
        [MinLength( 6, ErrorMessage = "Пароль должен быть не короче {1} символов" )]
        [DataType( DataType.Password )]
        public string Password { get; set; }
        
        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        [Compare( "Password", ErrorMessage = "Пароль введен неверно" )]
        [DataType( DataType.Password )]
        public string ConfirmPassword { get; set; }
    }
}