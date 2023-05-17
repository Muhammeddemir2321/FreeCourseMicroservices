using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Repositories;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FreeCourse.Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto course)
        {
            var courseEntity = _mapper.Map<Course>(course);
            await _courseRepository.CreateAsync(courseEntity);
            var courseDto = _mapper.Map<CourseDto>(courseEntity);
            return Response<CourseDto>.Succes(courseDto, StatusCodes.Status201Created);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var entity = await _courseRepository.GetByIdAsync(id);
            if(entity == null)
            {
                Response<NoContent>.Fail("Not found course", StatusCodes.Status404NotFound,true);
            }
            _courseRepository.Delete(entity);
            return Response<NoContent>.Succes(StatusCodes.Status201Created);
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courseEntities = await _courseRepository.GetAllAsync();
            var courseDtos = _mapper.Map<List<CourseDto>>(courseEntities);
            return Response<List<CourseDto>>.Succes(courseDtos, StatusCodes.Status200OK);
        }

        public async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courseEntities=await _courseRepository.GetAllByUserIdAsync(userId);
            var courseDtos = _mapper.Map<List<CourseDto>>(courseEntities);
            return Response<List<CourseDto>>.Succes(courseDtos, StatusCodes.Status200OK);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var courseEntity=await _courseRepository.GetByIdAsync(id);
            if(courseEntity == null)
            {
                return Response<CourseDto>.Fail("Course not found", StatusCodes.Status404NotFound, true);
            }
            var categoryDto=_mapper.Map<CourseDto>(courseEntity);

            return Response<CourseDto>.Succes(categoryDto, StatusCodes.Status200OK);
        }

        public Task<Response<NoContent>> UpdateAsync(CourseUpdateDto course)
        {
            var entity = _mapper.Map<Course>(course);_courseRepository.Update(entity);
            return Task.FromResult(Response<NoContent>.Succes(StatusCodes.Status204NoContent));
        }
    }
}
