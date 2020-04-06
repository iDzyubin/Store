namespace Store.BusinessLogic.Models.Product
{
    /// <summary>
    /// Результат регистрации
    /// </summary>
    public class SignUpResultModel
    {
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public string AlertType { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string AlertMessage { get; set; }
    }
}