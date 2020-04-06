using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Services.Password;
using Store.BusinessLogic.Services.Sale;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.BusinessLogic.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        public AccountService
        ( 
            IPasswordService passwordService, 
            IUserRepository userRepository, 
            ISaleService saleService, 
            IMapper mapper 
        )
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
            _saleService = saleService;
            _mapper = mapper;
        }

        public async Task<bool> IsUserSignUpAsync( string email )
        {
            var user = await _userRepository.GetByEmailAsync( email );
            return user != null;
        }

        public async Task SignUpAsync( SignUpModel model )
        {
            var item = await _userRepository.GetAsync( model.Id );
            if( item != null && item.Status != UserStatus.Temporary )
            {
                return;
            }
            var user = _mapper.Map<User>( model );
            user.Password = _passwordService.GetHash( model.Password );
            await _userRepository.InsertAsync( user );
        }

        public async Task<(bool isSuccess, Dictionary<string, string> errors)> ValidateAsync( string email, string password )
        {
            var errors = new Dictionary<string, string>();

            var user = await _userRepository.GetByEmailAsync( email );
            if( user == null )
            {
                errors[nameof(email)] = $"Пользователь {email} не существует";
                return ( false, errors );
            }

            var isValidPassword = _passwordService.ValidateHash( password, user.Password );
            if( !isValidPassword )
            {
                errors[nameof(password)] = "Пароль некорректный. Попробуйте снова";
                return ( false, errors );
            }

            return ( true, errors );
        }

        public async Task<User> GetUserAsync( string email )
        {
            var user = await _userRepository.GetByEmailAsync( email );
            return user;
        }

        public async Task<User> GetUserAsync( Guid id )
        {
            var user = await _userRepository.GetAsync( id );
            return user;
        }

        public async Task<UserExtendedInfoModel> GetUserExtendedInfoAsync( Guid userId )
        {
            var user = await _userRepository.GetAsync( userId );
            var model = _mapper.Map<UserExtendedInfoModel>( user );
            model.Sales = await _saleService.GetTransactionsAsync( userId );
            return model;
        }

        public async Task<string> GetShortNameAsync( Guid userId )
        {
            var user = await _userRepository.GetAsync( userId );
            return $"{user?.FirstName ?? String.Empty} {user?.LastName.Substring( 0, 1 ) ?? String.Empty}.";
        }

        public async Task CreateTemporaryAccountAsync( Guid userId )
        {
            var user = new User
            {
                Id = userId,
                FirstName = Guid.NewGuid().ToString(),
                LastName  = Guid.NewGuid().ToString(),
                Email     = Guid.NewGuid().ToString(),
                Password  = Guid.NewGuid().ToString(),
                Status    = UserStatus.Temporary
            };
            await _userRepository.InsertTemporaryUser( user );
        }

        public async Task<bool> IsTemporaryUserAsync( Guid userId )
        {
            var user = await _userRepository.GetAsync( userId );
            return user.Status == UserStatus.Temporary;
        }

        public async Task ActivateTemporaryAccountAsync( SignUpModel model )
        {
            var user = _mapper.Map<User>( model );
            user.Password = _passwordService.GetHash( model.Password );
            user.Status = UserStatus.Approved;
            await _userRepository.UpdateAsync( user );
        }
    }
}