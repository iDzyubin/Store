using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.Account
{
    public class SignUpModel
    {
        [Required( ErrorMessage = "Не указан Email" )]
        [EmailAddress( ErrorMessage = "Недействительный e-mail адрес" )]
        public string Email { get; set; }
        
        [Required( ErrorMessage = "Не указано имя" )]
        [MaxLength( 50, ErrorMessage = "Длина имени не может превышать {1} символов" )]
        public string FirstName { get; set; }
        
        [Required( ErrorMessage = "Не указана фамилия" )]
        [MaxLength( 50, ErrorMessage = "Длина фамилии не может превышать {1} символов" )]
        public string LastName { get; set; }
        
        [Required( ErrorMessage = "Не указан пароль" )]
        [MinLength( 6, ErrorMessage = "Пароль должен быть не короче {1} символов" )]
        [DataType( DataType.Password )]
        public string Password { get; set; }
        
        [Compare( "Password", ErrorMessage = "Пароль введен неверно" )]
        [DataType( DataType.Password )]
        public string ConfirmPassword { get; set; }
    }
}