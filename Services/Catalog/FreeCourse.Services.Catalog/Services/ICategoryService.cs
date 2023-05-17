using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto category);
        Task<Response<NoContent>> UpdateAsync(CategoryDto category);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
