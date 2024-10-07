using AutoMapper;
using EShop.Core.Models;
using EShop.Persistence.Entities;

namespace Eshop.Persistence.Mappings;
public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<UserEntity, User>();
        CreateMap<User, UserEntity>();
        CreateMap<EmailAdress, EmailAdressEntity>();
        CreateMap<EmailAdressEntity, EmailAdress>();
        CreateMap<PhoneNumber, PhoneNumberEntity>();
        CreateMap<PhoneNumberEntity, PhoneNumber>();
    }
}