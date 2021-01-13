using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.Models.DTOs.StudentMapper
{
    public class StudentMappings : Profile
    {
        public StudentMappings()
        {
            CreateMap<StudentModel, StudentDTO>().ReverseMap();
            CreateMap<StudentModel, StudentCreateDTO>().ReverseMap();
            CreateMap<StudentModel, StudentUpdateDTO>().ReverseMap();
        }
    }
}
