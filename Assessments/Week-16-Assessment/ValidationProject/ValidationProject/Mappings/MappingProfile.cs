using AutoMapper;
using ValidationProject.DTOs;
using ValidationProject.Models;

namespace ValidationProject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCourseDto, Course>();
            CreateMap<Course, CreateCourseDto>();

            CreateMap<UpdateDto, Course>();
            CreateMap<Course, UpdateDto>();

            CreateMap<GetAllDto, Course>();
            CreateMap<Course, GetAllDto>();

            CreateMap<GetByIdDto, Course>();
            CreateMap<Course, GetByIdDto>();
        }
    }
}
