using AutoMapper;
using Common.Pagination;
using Domain.DTO;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<GetUserDTO, User>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<LoginDTO, UserDTO>().ReverseMap();
            CreateMap<LoginDTO, User>().ReverseMap();
            CreateMap<SearchPaginationDTO<UserDTO>, Pagination<UserDTO>>().ReverseMap();
            CreateMap<List<User>, List<UserDTO>>().ReverseMap();
            CreateMap<SearchPaginationDTO<ProductDTO>, Pagination<Product>>().ReverseMap();
        }

    }
}
