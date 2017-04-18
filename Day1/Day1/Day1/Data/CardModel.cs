using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Data
{
    [Table("Cards")]
    public class CardModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column("IsPhoneCall")]
        public bool IsPhoneCallCard { get; set; }

        //FK a MyList rekordra, amelyiken ez a kártya is rajta van.
        [Indexed]
        public int MyListId { get; set; }

    }
}
