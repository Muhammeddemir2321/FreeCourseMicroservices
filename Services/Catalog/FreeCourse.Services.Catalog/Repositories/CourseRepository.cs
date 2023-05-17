using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Repositories
{
    public class CourseRepository:ICourseRepository
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly ICategoryRepository _categoryRepository;

        public CourseRepository(IDatabaseSettings databaseSettings, ICategoryRepository categoryRepository)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(Course course)
        {
            await _courseCollection.InsertOneAsync(course);
        }

        public void Delete(Course course)
        {
            _courseCollection.DeleteOne(x=>x.Id == course.Id);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(Course => true).ToListAsync();
            if(!courses.Any())
            {
                return new List<Course>();
            }
            foreach(var course in courses)
            {
                course.Category = await _categoryRepository.GetByIdAsync(course.CategoryId);
            }
            return courses;

        }

        public async Task<Course> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Course>(x => x.Id == id).FirstOrDefaultAsync();
            if (course == null) return null;
            course.Category = await _categoryRepository.GetByIdAsync(course.CategoryId);
            return course;
        }

        public async Task<List<Course>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find<Course>(x => x.UserId == userId).ToListAsync();
            if (!courses.Any())
            {
                return new List<Course>();
            }
            foreach (var course in courses)
            {
                course.Category = await _categoryRepository.GetByIdAsync(course.CategoryId);
            }
            return courses;
        }

        public async void Update(Course course)
        {
            await _courseCollection.FindOneAndReplaceAsync(x => x.Id == course.Id, course);
        }
    }
}
