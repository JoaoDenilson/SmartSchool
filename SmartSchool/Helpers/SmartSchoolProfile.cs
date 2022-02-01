using AutoMapper;
using SmartSchool.Dtos;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Name}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateBirth.GetCurrentAge())
                );
        }
    }
}
