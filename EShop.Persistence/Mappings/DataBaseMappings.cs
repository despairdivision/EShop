using AutoMapper;
using EShop.Core.Models;
using EShop.Persistence.Entities;

namespace Eshop.Persistence.Mappings;
public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>();

        CreateMap<EmailAdress, EmailAddressEntity>();
        CreateMap<EmailAddressEntity, EmailAdress>();

        CreateMap<PhoneNumber, PhoneNumberEntity>();
        CreateMap<PhoneNumberEntity, PhoneNumber>();

        CreateMap<Product, ProductEntity>();
        CreateMap<ProductEntity, Product>();
    }
}