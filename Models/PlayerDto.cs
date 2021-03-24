using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_.Models
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public int NumberOfPoints { get; set; }
        [MaxLength(100)]
        public int Level { get; set; }
    }
}
