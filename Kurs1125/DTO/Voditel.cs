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

        [Column("mcar")]
        public string mcar { get; set; }

        [Column("ncar")]
        public string ncar { get; set; }

        [Column("color")]
        public string color { get; set; }
    }
}
