using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoArchitecture.DL.Database
{
	public class MongoConnector<T> : IDbContext<T> where T : class
	{
		private readonly MongoDbContext _mongoDbContext;
		private readonly string _collectionName;
		private readonly IMongoCollection<T> _mongoCollection;

		public MongoConnector(MongoDbContext mongoDbContext)
		{
			_mongoDbContext = mongoDbContext;
			_collectionName = Activator.CreateInstance<T>().GetType().Name.ToString();
			_mongoCollection = _mongoDbContext.MongoDatabase.GetCollection<T>(_collectionName);
		}

		public async Task<T> CreateEntity(T entity)
		{
			await _mongoCollection.InsertOneAsync(entity);
			return entity;
		}

		public async Task<T> DeleteEntity(T entity)
		{
			await _mongoCollection.DeleteOneAsync(x => x == entity);
			return entity;
		}

		public IEnumerable<T> GetAll()
		{
			var entities = _mongoCollection.AsQueryable<T>();
			return entities.ToList();
		}

		public IEnumerable<T> GetRecords(int limit)
		{
			var entities = _mongoCollection.Find(entity => true).Skip(0).Limit(limit).ToList();
			return entities;
		}
	}
}
