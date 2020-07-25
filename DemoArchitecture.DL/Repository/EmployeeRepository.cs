using DemoArchitecture.DL.Database;
using DemoArchitecture.Entity;
using DemoArchitecture.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoArchitecture.DL.Repository
{
	public class EmployeeRepository : BaseRepository<Employee>
	{
		public EmployeeRepository(IDbContext<Employee> dbContext) : base(dbContext)
		{
			
		}

	}
}
