using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_.Data
{
    public class Words
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string WordsToLearn { get; set; }
        [MaxLength(100)]
        public string WordsTranslated { get; set; }
        public int PointsId { get; set; }

    }
}
