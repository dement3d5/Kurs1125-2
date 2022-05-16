using Kurs1125.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.DTO
{
    [Table("dispet")]
    public class Dispet : BaseDTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fname")]
        public string Fname { get; set; }

        [Column("login")]
        public string Log { get; set; }

        [Column("password")]
        public string Pas { get; set; }
    }
}