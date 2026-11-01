using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieService(IMovieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _movies = database.GetCollection<Movie>(settings.MoviesCollectionName);
        }

        public List<Movie> Get() => _movies.Find(new BsonDocument()).ToList();

        public List<Movie> GetByFilter(FilterDefinition<Movie> filter, int? limit = null) => _movies.Find(filter).Limit(null).ToList();

        //public List<object> GetByFilter(FilterDefinition<Movie> filter, int? limit = null)
        //{
        //    return _movies.Find(filter).Limit(null).ToList();
        //}

        public Movie Get(int id) => _movies.Find(movie => movie.Id == $"movie:{id}").FirstOrDefault();

        public Movie Create(Movie movie)
        {
            _movies.InsertOne(movie);
            return movie;
        }

        public void Update(int id, Movie movie) => _movies.ReplaceOne(m => m.Id == $"movie:{id}", movie);

        public void Remove(Movie movie) => _movies.DeleteOne(m => m.Id == movie.Id);

        public void Remove(int id) => _movies.DeleteOne(m => m.Id == $"movie:{id}");
    }
}
