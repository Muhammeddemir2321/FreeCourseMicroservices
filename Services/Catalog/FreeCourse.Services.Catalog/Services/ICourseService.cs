using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto course);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto course);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
    }
}
