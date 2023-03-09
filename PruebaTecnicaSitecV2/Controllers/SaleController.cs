using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSitecV2.Data;
using PruebaTecnicaSitecV2.DTO;
using PruebaTecnicaSitecV2.Interfaces;
using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleservice;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly AppDbContext _db;
        public SaleController(ISaleService saleservice, IClientService clientService, IProductService productService,AppDbContext db)
        {
            _saleservice = saleservice;
            _clientService = clientService;
            _productService = productService;
            _db = db;
            
        }
        [HttpGet("GetSales")]
        public IActionResult GetSales()
        {
            var result = _saleservice.GetSales();
            return Ok(result);
        }
        [HttpGet("GetSalesByClient")]
        public IActionResult GetSalesByClient([FromHeader] int id)
        {
            var result = _saleservice.GetSalesByClient(id);
            return Ok(result);
        }
        [HttpGet("GetSalesByProduct")]
        public IActionResult GetSalesByProduct([FromHeader] int id)
        {
            var result = _saleservice.GetSalesByProduct(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult ProcessSale([FromBody] KartDTO body)
        {
            List<Product> ProductList = new List<Product>();
            List<ProductSale> ItemList = new List<ProductSale>();
            decimal TotalPrice = 0;
            if (_clientService.VerifyClient(body.ClientId) == false)
            {
                return BadRequest("Este cliente no existe");
            }
            foreach (var obj in body.Items)
            {
                var product = _productService.GetProductById(obj.ProductId);
                if (product == null)
                {
                    return BadRequest("El producto " + obj.ProductId.ToString() + " no existe");
                }
                if (product.ProductStock < obj.quantity)
                {
                    return BadRequest("No hay suficiente stock del producto " + obj.quantity.ToString());
                }
                ProductSale productsale = new ProductSale()
                {
                    ProductId=obj.ProductId,
                    ProductQuantity=obj.quantity,
                    ProductBill=product.ProductPrice*obj.quantity,
                };
                product.ProductStock-=obj.quantity;
                ProductList.Add(product);
                ItemList.Add(productsale); 
                TotalPrice += product.ProductPrice * obj.quantity;
            }
            Sale sale = new Sale()
            {
                ClientId = body.ClientId,
                BillBeforeTaxes = TotalPrice,
                BillAfterTaxes = TotalPrice * Convert.ToDecimal(1.13),
                ProductSales=ItemList
            };
            var result = _saleservice.PostSale(sale);
            _productService.PutMany(ProductList);
            return Ok(result);

        }
    }
}
