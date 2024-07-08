using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public class OrderReposatory : GenericReposatories<Order>, IOrder
    {
        private readonly ApplicationDbContext context;
        public OrderReposatory(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public Order GetById(string id)
        {
            return context.Orders.Find(id);
        }
        public void Delete(string id)
        {
            Order Entity = GetById(id);
            context.Remove(Entity);
        }
    }
}
