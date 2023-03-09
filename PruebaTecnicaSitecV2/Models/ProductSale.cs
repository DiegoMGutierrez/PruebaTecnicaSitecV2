using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PruebaTecnicaSitecV2.Models
{
    public class ProductSale
    {
        [Key]
        public int ProductSaleId { get; set; }
        [ForeignKey("Sale")]
        public int SaleId { get; set; }=0;
        [JsonIgnore]

        public Sale? Sale { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public  Product? Product { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public decimal ProductBill { get; set; }
    }
}
