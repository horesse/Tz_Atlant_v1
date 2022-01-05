using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TZ_ver2.Data.Models
{
    public class Details
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "Введите Нуменкулаторный код.")]
        public string Num_code { get; set; }
        [Required(ErrorMessage = "Введите название детали.")]
        public string name { get; set; }
        public int count { get; set; }
        [Required(ErrorMessage = "Выберите кладовщика.")]
        public int SkeeperID { get; set; }
        public virtual Skeeper Skeeper { get; set; }
        [Required(ErrorMessage = "Выберите дату создания детали.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DeleteDate { get; set; }
    }
}
