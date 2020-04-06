using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqToDB;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDb _db;

        public UserRepository( MainDb db )
            => _db = db;

        public async Task InsertAsync( User item )
        {
            item.Status = UserStatus.Approved;
            item.Id = Guid.NewGuid();
            await _db.InsertAsync( item );
        }

        public async Task InsertTemporaryUser( User user )
        {
            await _db.InsertAsync( user );
        }

        public async Task UpdateAsync( User item )
            => await _db.UpdateAsync( item );

        public Task DeleteAsync( Guid id )
            => _db.Users.DeleteAsync( x => x.Id == id );

        public async Task<User> GetAsync( Guid id )
            => await _db.Users.FirstOrDefaultAsync( x => x.Id == id );

        public async Task<IEnumerable<User>> GetAsync()
            => await _db.Users.ToListAsync();

        public async Task<User> GetByEmailAsync( string email )
            => await _db.Users.FirstOrDefaultAsync( x => x.Email.ToLower() == email.ToLower() );
    }
}