using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(string id);
        Task CreateAsync(Course course);
        void Update(Course course);
        void Delete(Course course);
        Task<List<Course>> GetAllByUserIdAsync(string userId);
    }
}
