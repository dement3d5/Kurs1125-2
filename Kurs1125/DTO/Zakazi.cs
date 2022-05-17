using Kurs1125.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.DTO
{


    [Table("zakazi")]
    public class Zakazi : BaseDTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("dtincome")]
        public DateTime Dtincome { get; set; }

        [Column("dtdestination")]
        public DateTime Dtdestination { get; set; }

        [Column("destination")]
        public string Destination { get; set; }

        [Column("place of departure")]
        public string Pod { get; set; }
        
        [Column("price")]
        public string Price { get; set; }

        [Column("Dispet_id")]
        public int Dispet_id { get; set; }
        
        [Column("Abonent_id")]
        public int Abonent_id { get; set; }
        
        [Column("Voditel_id")]
        public int Voditel_id { get; set; }

    }
}
