using AutoMapper;
using MsDiscountGrpc.Entities;
using MsDiscountGrpc.Protos;

namespace MsDiscountGrpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}