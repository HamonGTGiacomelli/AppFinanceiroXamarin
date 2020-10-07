using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppFinanceiro.Model
{
    public class UserEntry
    {
        [PrimaryKey, AutoIncrement]
        public uint id { get; set; }
        public string title { get; set; }
        public double value { get; set; }
        public EntryType type { get; set; }
    }
}
