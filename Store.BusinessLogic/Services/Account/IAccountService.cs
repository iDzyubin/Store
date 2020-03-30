using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models;
using Store.BusinessLogic.Models.Account;
using Store.DataAccess.DataModels;

namespace Store.BusinessLogic.Services.Account
{
    public interface IAccountService
    {
        Task<bool> IsUserSignUpAsync( string email );

        Task SignUpAsync( SignUpModel model );

        Task<(bool isSuccess, Dictionary<string, string> errors)> ValidateAsync( string email, string password );

        Task<User> GetUserAsync( string email );

        Task<UserExtendedInfoModel> GetUserExtendedInfoAsync( Guid userId );

        Task<string> GetShortNameAsync( Guid id );
    }
}