using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoArchitecture.DL.Database
{
	public interface IDbContext<T> where T :class
	{
		IEnumerable<T> GetAll();
		//Task<T> GetByIdAsync(string id);
		Task<T> CreateEntity(T entity);
		Task<T> DeleteEntity(T entity);
		IEnumerable<T> GetRecords(int limit);
	}
}
