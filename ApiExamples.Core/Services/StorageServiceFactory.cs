using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.MvvmCross.Community.Plugins.Sqlite;


namespace ApiExamples.Core.Services
{
    class StorageServiceFactory : IStorageServiceFactory
    {
        ISQLiteConnectionFactory _connectionFactory;

        public StorageServiceFactory(ISQLiteConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }  


        public DB.IEntityStorage<T> getStorageForEntity<T>() where T : DB.DBRecord, new()
        {
            return new DB.EntityStorage<T>(_connectionFactory);
        }
    }
}
