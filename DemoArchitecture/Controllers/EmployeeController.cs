using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoArchitecture.BL.Interfaces;
using DemoArchitecture.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoArchitecture.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {


        public EmployeeController(IBaseBL<Employee> emp) : base(emp)
        {
        }

        [HttpGet]
        //public IEnumerable<Employee> GetEmployees()
        //{
        //    var entities = _baseBL.GetAllBL();
        //    return entities;
        //}
        public string Get()
        {
            return "Hello";
        }

    }
}