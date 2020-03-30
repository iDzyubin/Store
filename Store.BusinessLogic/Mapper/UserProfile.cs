using AutoMapper;
using Store.BusinessLogic.Models;
using Store.BusinessLogic.Models.Account;
using Store.DataAccess.DataModels;

namespace Store.BusinessLogic.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, SignInModel>().ReverseMap();
            CreateMap<User, SignUpModel>().ReverseMap();
            CreateMap<User, UserExtendedInfoModel>().ReverseMap();
        }
    }
}