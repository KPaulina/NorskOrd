using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_
{
    public class AddNewWordDto
    {
        [Required]
        [MaxLength(100)]
        public string WordsToLearn { get; set; }
        [Required]
        [MaxLength(100)]
        public string WordsTranslated { get; set; }
    }
}
