using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public class ProductReposatory : GenericReposatories<Product>, IProduct
    {
        private readonly ApplicationDbContext context;
        public ProductReposatory(ApplicationDbContext context) : base(context)
        {
            this.context=context;
        }
    }
}
