using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> Users = new List<User>();
        
        public async Task InsertAsync( User item )
        {
            item.Id = Guid.NewGuid();
            Users.Add( item );
        }

        public async Task UpdateAsync( User item )
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync( Guid id )
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync( Guid id )
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmailAsync( string email )
        {
            return Users.FirstOrDefault( x => x.Email.ToLower() == email.ToLower() );
        }
    }
}