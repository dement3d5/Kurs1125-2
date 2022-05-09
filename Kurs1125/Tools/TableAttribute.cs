using System;

namespace Kurs1125.Tools
{
    internal class TableAttribute : Attribute
    {
        public string Table { get; }
        public TableAttribute(string table)
        {
            Table = table;
        }
    }
}