using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSitecV2.Interfaces;

namespace PruebaTecnicaSitecV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;
        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryservice.GetCategories());
        }
    }
}
