using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoArchitecture.BL.Interfaces
{
	public interface IBaseBL<T> where T : class
	{
		IEnumerable<T> GetAllBL();
		//Task<T> GetByIdAsync(string id);
		Task<T> CreateEntityBL(T entity);
		Task<T> DeleteEntityBL(T entity);
		IEnumerable<T> GetRecordsBL(int limit);
	}
}
