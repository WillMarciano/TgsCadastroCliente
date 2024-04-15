using Application.Dtos;
using Domain.Identity;
using AutoMapper;
using Domain.Entity;

namespace Application.Helpers
{
    public class CadastroClienteProfile : Profile
    {
        public CadastroClienteProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserLoginRegisterDto>().ReverseMap();

            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDto>().ReverseMap();
        }
    }
}
