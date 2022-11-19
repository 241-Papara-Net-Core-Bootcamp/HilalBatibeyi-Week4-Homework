using AutoMapper;
using Owner.API.Model;
using Owner.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owner.Business.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OwnerModel, OwnerDto>().ReverseMap();
        }
    }
}
