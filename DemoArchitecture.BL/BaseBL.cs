using DemoArchitecture.BL.Interfaces;
using DemoArchitecture.DL.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoArchitecture.BL
{
	public class BaseBL<T> : IBaseBL<T> where T : class
	{
		public readonly IRepository<T> _repository;

		public BaseBL(IRepository<T> repository)
		{
			_repository = repository;
		}


		public Task<T> CreateEntityBL(T entity)
		{
			return _repository.CreateEntityDL(entity);
		}

		public Task<T> DeleteEntityBL(T entity)
		{
			return _repository.DeleteEntityDL(entity);
		}

		public IEnumerable<T> GetAllBL()
		{
			return _repository.GetAllDL();
		}

		public IEnumerable<T> GetRecordsBL(int limit)
		{
			return _repository.GetRecordsDL(limit);
		}
	}
}
