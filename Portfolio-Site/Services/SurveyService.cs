using PortfolioSite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PortfolioSite.Services
{
    public class SurveyService
    {

        private readonly IMongoCollection<Survey> _collection;

        public SurveyService(
            IOptions<DbSettings> dbsettings)
        {
            var mongoClient = new MongoClient(
                dbsettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbsettings.Value.DB);

            _collection = mongoDatabase.GetCollection<Survey>(
                dbsettings.Value.Collection);
        }

        public async Task<List<Survey>> GetAsync() =>
            await _collection.Find(_=>true).Project<Survey>(Builders<Survey>.Projection.Exclude(x=>x.Password)).ToListAsync();

        public async Task<Survey?> GetAsync(string id, string password) =>
            await _collection.Find(x => x.Id == id & x.Password == password).FirstOrDefaultAsync();

        public async Task<Survey?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).Project<Survey>(Builders<Survey>.Projection.Exclude(x => x.Password)).FirstOrDefaultAsync();
        public async Task CreateAsync(Survey newSurvey) =>
            await _collection.InsertOneAsync(newSurvey);

        public async Task UpdateAsync(Survey updatedSurvey) =>
            await _collection.ReplaceOneAsync(x => x.Id == updatedSurvey.Id, updatedSurvey);

        public async Task RemoveAsync(string id,string password) =>
            await _collection.DeleteOneAsync(x => x.Id == id & x.Password == password);
    }
}

