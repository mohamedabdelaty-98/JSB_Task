using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descrption { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be Positve")]
        public decimal price { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Stock must be Positve")]
        public int stock { get; set; }
        [ForeignKey("order")]
        public string? OrderId { get; set; }
        public virtual Order? order  { get; set; }
    }
}
