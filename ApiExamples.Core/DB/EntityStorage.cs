using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.MvvmCross.Community.Plugins.Sqlite;


namespace ApiExamples.Core.DB
{
    class EntityStorage<T> : IEntityStorage<T> where T : DBRecord, new()
    {
        private ISQLiteConnection _connection;


        public EntityStorage(ISQLiteConnectionFactory connectionFactory) {
            _connection = connectionFactory.Create("mydb.sql");
            _connection.CreateTable<T>();
        }

        public List<T> QueryItems(string query, params object[] args)
        {
            string actualQuery = String.Format(query, args);
            return _connection.Query<T>(actualQuery);
        }

        public void Insert(T item) {
            _connection.Insert(item);
        }

        public void Update(T item) {
            _connection.Update(item);
        }

        public void Delete(T item) {
            _connection.Delete(item);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<T>();
        }

        public string getTableName() {
            string name = typeof(T).ToString();
            return name.Substring(name.LastIndexOf('.') + 1); // dodelat do connectionu tablename 
        }

        public int Count {
            get {
                return 1; // select count
            }
        }
    }
}
