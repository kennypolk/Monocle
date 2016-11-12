﻿using System.Collections.Generic;
using Monocle.Repository.Interfaces;

namespace Monocle.Repository
{
    public interface IRepository<T> 
    {
        T Get(int id);
        List<T> Get();
        List<T> Get(object whereConditions);
        List<T> Get(string conditions, object parameters = null);
        int? Insert(T item);
        int Update(T item);
        int Delete(T item);
        int Delete(int id);
        int DeleteList(object whereConditions);
        int DeleteList(string conditions, object parameters = null);
        int RecordCount(string conditions = "", object paramerters = null);
    }
}
