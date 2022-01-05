using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TZ_ver2.Data.Models
{
    public class Skeeper
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Введите имя кладовщика")]
        public string name { get; set; }
        public List<Details> details { get; set; }
    }
}
