using DemoArchitecture.DL.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoArchitecture.DL.Repository
{
	public class BaseRepository<T> : IRepository<T> where T : class
	{
		public readonly IDbContext<T> _dbContext;
		//public MongoConnector<T> _dbContext;
		public BaseRepository(IDbContext<T> dbContext)
		{
			_dbContext = dbContext;
			//_dbContext = new MongoConnector<T>();
		}

		public Task<T> CreateEntityDL(T entity)
		{
			return _dbContext.CreateEntity(entity);
		}

		public Task<T> DeleteEntityDL(T entity)
		{
			return _dbContext.DeleteEntity(entity);
		}

		public  IEnumerable<T> GetAllDL()
		{
			return  _dbContext.GetAll();
		}

		public IEnumerable<T> GetRecordsDL(int limit)
		{
			return _dbContext.GetRecords(limit);
		}
	}
}
