using AutoMapper;
using Store.BusinessLogic.Models.Basket;
using Store.BusinessLogic.Models.Sales;
using Store.DataAccess.DataModels;

namespace Store.BusinessLogic.Mapper
{
    public class SaleItemProfile : Profile
    {
        public SaleItemProfile()
        {
            CreateMap<SaleItem, SaleItemModel>().ReverseMap();
            CreateMap<SaleItem, BasketLine>().ReverseMap();
        }
    }
}