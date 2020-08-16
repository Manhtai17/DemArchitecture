using DemoArchitecture.DL.Repository;
using DemoArchitecture.Entity.Entities;

namespace DemoArchitecture.BL
{
	public class EmployeeBL : BaseBL<Employee>
	{
		public EmployeeBL(IRepository<Employee> repository) : base(repository)
		{

		}


	}
}
