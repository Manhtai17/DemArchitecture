using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoArchitecture.DL.Database
{
	public class MariaConnector<T> : IDbContext<T> where T : class
	{
		public readonly MariaDbContext _dbContext;

		public MariaConnector(MariaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public virtual async Task<T> CreateEntity(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<T> DeleteEntity(T entity)
		{

			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public virtual IEnumerable<T> GetAll()
		{
			var entities = _dbContext.Set<T>();
			return entities;
		}

		public IEnumerable<T> GetRecords(int limit)
		{
			return _dbContext.Set<T>().Take<T>(limit);
		}

	}
}
