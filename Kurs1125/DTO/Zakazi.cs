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

        [Column("Abonent_id")]
        public int AB1 { get; set; }

        [Column("number_dispatchs")]
        public int ND { get; set; }

        [Column("Voditel_id")]
        public int Vid { get; set; }







    }
}
