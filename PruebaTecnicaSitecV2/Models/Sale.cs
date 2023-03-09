using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PruebaTecnicaSitecV2.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [JsonIgnore]
        public virtual Client? Client { get; set; }
        public decimal? BillBeforeTaxes { get; set; }
        public decimal? BillAfterTaxes { get; set; }
        
        public virtual ICollection<ProductSale> ProductSales { get; set; }

    }
}
