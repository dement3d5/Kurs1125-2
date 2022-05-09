using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.DTO
{


    [Table("Zakazi")]
    public class Zakazi : BaseDTO
    {

        [Column("id_orders")]
        public int Orders { get; set; }

        [Column("dtincome")]
        public DateTime dtincome { get; set; }

        [Column("dtdestination")]
        public DateTime dtdestination { get; set; }

        [Column("place of departure")]
        public string pod { get; set; }
        [Column("price")]
        public string price { get; set; }

        [Column("destination")]
        public string destination { get; set; }




    }
}
