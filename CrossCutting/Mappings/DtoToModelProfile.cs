using AutoMapper;
using Domain.Dto.User;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserEntity, UserDto>()
                    .ReverseMap();
            CreateMap<UserDto, UserEntity>()
                   .ReverseMap();
        }
    }
}
