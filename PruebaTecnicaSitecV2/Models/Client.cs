using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaSitecV2.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientEmail { get; set; }
        [Required]
        public string ClientMobile { get; set; }
        [Required]
        public string ClientDNI { get; set; }
    }
}
