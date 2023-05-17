using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryRepository(IDatabaseSettings databaseSettings)
        {
            var client=new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task CreateAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories=await _categoryCollection.Find(category=>true).ToListAsync();
            return categories;
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
