using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;


namespace ApiExamples.Core.ViewModels
{
    class StorageViewModel : TestViewModel 
    {
        private readonly DB.IEntityStorage<DB.Sample> _sampleStorage;

        public List<string> OriginalItems { get ; set; }
        public List<string> FilteredItems { get; set; }


        public StorageViewModel(Services.IStorageServiceFactory storageServiceFactory)
        {
            _sampleStorage = storageServiceFactory.getStorageForEntity<DB.Sample>();

            _sampleStorage.DeleteAll();

            _sampleStorage.Insert(new DB.Sample() { Name = "Granat" } );
            _sampleStorage.Insert(new DB.Sample() { Name = "Jablko" } );
            _sampleStorage.Insert(new DB.Sample() { Name = "Granat" } );
            _sampleStorage.Insert(new DB.Sample() { Name = "Hruska" } );
            _sampleStorage.Insert(new DB.Sample() { Name = "Granat" } );

            // get all items in DB
            string query1 = "SELECT * FROM {0}";

            List<DB.Sample> list1 = _sampleStorage.QueryItems(query1, new object[] { _sampleStorage.getTableName() });

            OriginalItems = new List<string>();
            foreach (DB.Sample sample in list1)
            {
                OriginalItems.Add(sample.Name);
            };


            // get items in DB with name = Granat 
            string query2 = "SELECT * FROM {0} WHERE NAME = \"{1}\"";

            List <DB.Sample> list2 = _sampleStorage.QueryItems(query2, new object[] { _sampleStorage.getTableName() , "Granat" });

            FilteredItems = new List<string>();
            foreach (DB.Sample sample in list2) {
                FilteredItems.Add(sample.Name);
            };
        }
    }
}
