using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface IOrder:IGenericReposatories<Order>
    {
        Order GetById(string id);
        void Delete(string id);
    }
}
