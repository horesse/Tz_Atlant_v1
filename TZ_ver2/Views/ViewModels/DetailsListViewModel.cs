using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TZ_ver2.Data.Models;

namespace TZ_ver2.Views.ViewModels
{
    public class DetailsListViewModel
    {
        public IEnumerable<Details> AllDetails { get; set; }
        public IEnumerable<Skeeper> currSkeeper { get; set; }
    }
}
