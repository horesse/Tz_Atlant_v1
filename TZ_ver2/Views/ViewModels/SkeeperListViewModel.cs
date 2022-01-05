using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TZ_ver2.Data.Models;

namespace TZ_ver2.Views.ViewModels
{
    public class SkeeperListViewModel
    {
        public List<int> count { get; set; }
        public IEnumerable<Skeeper> skeeper { get; set; }
    }
}
