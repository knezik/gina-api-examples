using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.MvvmCross.Community.Plugins.Sqlite;


namespace ApiExamples.Core.DB
{
    public class Sample : DBRecord
    {
        public string Name { get; set; }
    }
}