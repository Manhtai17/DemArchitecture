using DemoArchitecture.DL.MongoSetting;
using MongoDB.Driver;

namespace DemoArchitecture.DL.Database
{
	public class MongoDbContext
	{
		private readonly IMongoClient _mongoClient;
		private readonly IMongoDatabase _mongoDatabase;

		public MongoDbContext(IDatabaseSetting databaseSetting)
		{
			_mongoClient = new MongoClient(databaseSetting.ConnectionString/*"mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false"*/);
			_mongoDatabase = _mongoClient.GetDatabase(databaseSetting.DatabaseName/*"Demo_PDMANH"*/);
		}

		public IMongoDatabase MongoDatabase { get => _mongoDatabase; }


	}
}
