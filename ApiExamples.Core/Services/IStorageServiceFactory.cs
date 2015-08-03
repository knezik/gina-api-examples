using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiExamples.Core.Services
{
    interface IStorageServiceFactory 
    {
        DB.IEntityStorage<T> getStorageForEntity<T>() where T : DB.DBRecord, new(); 
    }
}
