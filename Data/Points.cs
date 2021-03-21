using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_.Data
{
    public class Points
    {
        public int Id { get; set; }
        public int NumberOfPoints { get; set; }
        [MaxLength(100)]
        public int Level { get; set; }
        public int UserId { get; set; }
    }
}
