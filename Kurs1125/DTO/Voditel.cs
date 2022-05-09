using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.DTO
{
    [Table("Voditel")]
    public class Voditel : BaseDTO
    {
        [Column("fname")]
        public string fname { get; set; }

        [Column("lname")]
        public string lname { get; set; }

        [Column("mname")]
        public string mname { get; set; }

        [Column("birthday")]
        public DateTime birthday { get; set; }

        [Column("spassport")]
        public string spassport { get; set; }

        [Column("npassport")]
        public string npassport { get; set; }

        [Column("issued a passport")]
        public string issuedApassport { get; set; }

        [Column("dissued")]
        public DateTime dissued { get; set; }

        [Column("address")]
        public string address { get; set; }

        [Column("mcar")]
        public string mcar { get; set; }

        [Column("ncar")]
        public string ncar { get; set; }

        [Column("color")]
        public string color { get; set; }
    }
}
