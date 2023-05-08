using AutoMapper;
using Domain;
using Application.Orders;
using Application.Meals;
using Application.OrderItems;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Meal, Meal>();
            CreateMap<Meal, MealDto>();
            CreateMap<MealDto, Meal>();
            CreateMap<Order, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItem, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}