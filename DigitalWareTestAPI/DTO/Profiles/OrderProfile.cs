using AutoMapper;
using DigitalWare.Cross_cutting.DTO;
using DigitalWare.Domain.Models;

namespace DigitalWareTestAPI.DTO.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order_Detail, DetailsDTO>().ReverseMap();
            CreateMap<Product, ProductsListDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>()
                .ForMember(
                    dest => dest.OrderID,
                    opt => opt.MapFrom(src => src.OrderID)
                )
                .ForMember(
                    dest => dest.CustomerID,
                    opt => opt.MapFrom(src => src.CustomerID)
                )
                .ForMember(
                    dest => dest.OrderDate,
                    opt => opt.MapFrom(src => src.OrderDate)
                )

                .ForMember(
                    dest => dest.OrderID,
                    opt => opt.MapFrom(src => src.OrderID)
                )
                .ForMember(
                    dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.FullName)
                )
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => CalculateAmount(src.Order_Details, src.OrderID))
                );

        }

        private static decimal CalculateAmount(ICollection<Order_Detail> itemsList, int orderId)
        {
            var Result = itemsList.Where(p => p.OrderID == orderId)
                    .GroupBy(p => p.OrderID)
                    .Select(p => new { Amount = p.Sum(c => c.UnitPrice) * p.Sum(c => c.Quantity) })
                    .FirstOrDefault()!;

            return Result.Amount;
        }
    }
}
