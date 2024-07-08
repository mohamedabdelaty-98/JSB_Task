using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class DTOProduct
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
        public string? OrderId { get; set; }
        
    }
}
