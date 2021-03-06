using Kurs1125.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.DTO
{
    [Table("voditel")]
    public class Voditel : BaseDTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fname")]
        public string Fname { get; set; }

        [Column("lname")]
        public string Lname { get; set; }

        [Column("mcar")]
        public string Mcar { get; set; }

        [Column("ncar")]
        public string Ncar { get; set; }

        [Column("color")]
        public string Color { get; set; }


    }
}
