using DemoArchitecture.BL.Interfaces;
using DemoArchitecture.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoArchitecture.Controllers
{
	public class EmployeeController : BaseController<Employee>
	{

		public EmployeeController(IBaseBL<Employee> emp) : base(emp)
		{
		}

		[HttpGet]
		public IEnumerable<Employee> GetEmployees()
		{
			var entities = _baseBL.GetAllBL();
			return entities;
		}
		//public string Get()
		//{
		//    return "Hello";
		//}

	}
}