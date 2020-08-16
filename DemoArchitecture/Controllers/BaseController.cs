using DemoArchitecture.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        public readonly IBaseBL<T> _baseBL;

        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
    }
}