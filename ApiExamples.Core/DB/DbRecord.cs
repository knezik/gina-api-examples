using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.MvvmCross.Community.Plugins.Sqlite;


namespace ApiExamples.Core.DB
{
    public class DBRecord
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Updated { get; set; }

        public bool Deleted { get; set; }
    }
}
