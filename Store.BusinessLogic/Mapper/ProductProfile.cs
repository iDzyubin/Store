using AutoMapper;
using Store.BusinessLogic.Models.Product;
using Store.DataAccess.DataModels;

namespace Store.BusinessLogic.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}