using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Data
{
    [Table("MyLists")]
    public class MyListModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Picture { get; set; }

        //Az SQLite.NET nem ismer ilyet, ezért az FK-t
        //a másik oldalról kell definiálni
        //public ICollection<CardModel> Cards { get; set; }
    }
}
