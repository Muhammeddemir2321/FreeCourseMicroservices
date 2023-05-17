using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Repositories;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.CreateAsync(categoryEntity);
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return Response<CategoryDto>.Succes(categoryDto, StatusCodes.Status201Created);
        }

        public Task<Response<NoContent>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categoryEntities = await _categoryRepository.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categoryEntities);
            return Response<List<CategoryDto>>.Succes(categoryDtos, StatusCodes.Status200OK);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            if (categoryEntity==null)
            {
                return Response<CategoryDto>.Fail("Category not found", StatusCodes.Status404NotFound, true);
            }
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return Response<CategoryDto>.Succes(categoryDto, StatusCodes.Status200OK);
        }
        public Task<Response<NoContent>> UpdateAsync(CategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}
