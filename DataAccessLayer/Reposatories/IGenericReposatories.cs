﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface IGenericReposatories<T> where T : class
    {
        List<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        void insert(T Entity);
        void update(T Entity);
        void Delete(int id);
        int save();
    }
}
