using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSitecV2.Interfaces;
using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        private readonly ICategoryService _categoryservice;
        public ProductController(IProductService productservice, ICategoryService categoryservice)
        {
            _productservice = productservice;
            _categoryservice = categoryservice;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productservice.GetProducts());
        }
        [HttpPost]
        public IActionResult PostProduct([FromBody] Product body)
        {
            try
            {
                if (body.ProductStock < 0)
                {
                    return BadRequest("El stock no puede ser negativo");
                }
                if (body.ProductPrice < 0)
                {
                    return BadRequest("El precio no puede ser negativo");
                }
                if (_categoryservice.VerifyCategory(body.CategoryId) == true)
                {
                    var result = _productservice.PostProduct(body);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Esta categoria no existe");
                }

            }
            catch
            {
                return BadRequest("Por favor ingrese datos validos");
            }
        }
        [HttpPut]
        public IActionResult PutProduct([FromHeader] int id, [FromBody] Product body)
        {
            if (body.ProductStock < 0)
            {
                return BadRequest("El stock no puede ser negativo");
            }
            if (body.ProductPrice < 0)
            {
                return BadRequest("El precio no puede ser negativo");
            }
            if (_categoryservice.VerifyCategory(body.CategoryId) == false)
            {
                return BadRequest("La categoria a asignar no existe");
            }
            
            var result = _productservice.PutProduct(id, body);

            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("Este producto no existe");
        }
        [HttpDelete]
        public IActionResult DeleteProduct([FromHeader] int id)
        {
            var result = _productservice.DeleteProduct(id);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("El producto a eliminar no existe");
        }
        [HttpPatch("ModifyStock")]
        public IActionResult ModificarStock([FromHeader] int id, [FromHeader] int NewStock)
        {
            if (NewStock < 0)
            {
                return BadRequest("El stock no puede ser negativo");
            }
            var result = _productservice.PatchStock(id, NewStock);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("El producto a modificar no existe");
        }
        [HttpPatch("ModifyPrice")]
        public IActionResult ModificarPrecio([FromHeader] int id, [FromHeader] decimal NewPrice)
        {
            if (NewPrice < 0)
            {
                return BadRequest("El precio no puede ser negativo");
            }
            var result = _productservice.PatchPrice(id, NewPrice);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("El producto a modificar no existe");
        }
    }
}
