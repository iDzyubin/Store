using System;

namespace Store.DataAccess.DataModels
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public bool IsAdmin { get; set; }
        
        public string Password { get; set; }
    }
}