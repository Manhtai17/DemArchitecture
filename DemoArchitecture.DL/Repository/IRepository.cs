using DemoArchitecture.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoArchitecture.DL.Repository
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAllDL();
		//Task<T> GetByIdAsync(string id);
		Task<T> CreateEntityDL(T entity);
		Task<T> DeleteEntityDL(T entity);
		IEnumerable<T> GetRecordsDL(int limit);
	}
}
