using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseCreateDto, Course>().ReverseMap();
            CreateMap<CourseUpdateDto, Course>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<Feature, FeatureDto>().ReverseMap();

        }
    }
}
