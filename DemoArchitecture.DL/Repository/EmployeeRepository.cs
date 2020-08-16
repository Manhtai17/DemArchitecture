using DemoArchitecture.DL.Database;
using DemoArchitecture.Entity.Entities;

namespace DemoArchitecture.DL.Repository
{
	public class EmployeeRepository : BaseRepository<Employee>
	{
		public EmployeeRepository(IDbContext<Employee> dbContext) : base(dbContext)
		{

		}

	}
}
