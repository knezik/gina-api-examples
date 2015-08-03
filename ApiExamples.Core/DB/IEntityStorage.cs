using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiExamples.Core.DB
{
    interface IEntityStorage<T> where T : DBRecord, new()
    {
        List<T> QueryItems(string query, params object[] args);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        void DeleteAll();

        string getTableName();

        int Count { get;  }
    }
}
