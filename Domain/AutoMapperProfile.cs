using AutoMapper;
using Domain.DTO;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<GetUserDTO, User>().ReverseMap();
            CreateMap<SearchUserDTO, SearchPagingDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<LoginDTO, UserDTO>().ReverseMap();
            CreateMap<LoginDTO, User>().ReverseMap();

        }
    }
}
