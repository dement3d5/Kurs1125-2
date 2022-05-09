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
        public string Fname { get; set; }

        [Column("lname")]
        public string Lname { get; set; }

        [Column("mname")]
        public string mname { get; set; }

        [Column("birthday")]
        public DateTime birthday { get; set; }

        [Column("spassport")]
        public int spassport { get; set; }

        [Column("npassport")]
        public int npassport { get; set; }

        [Column("issued a passport")]
        public int issuedApassport { get; set; }

        [Column("dissued")]
        public int dissued { get; set; }

        [Column("address")]
        public string address { get; set; }

        [Column("mcar")]
        public int mcar { get; set; }

        [Column("ncar")]
        public int ncar { get; set; }

        [Column("color")]
        public int color { get; set; }
    }
}
