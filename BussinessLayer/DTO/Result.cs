using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class Result
    {
        public dynamic Data { get; set; }
        public string meesage { get; set; }
        public bool IsPass { get; set; }
    }
}
