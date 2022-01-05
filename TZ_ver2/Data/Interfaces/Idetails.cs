using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TZ_ver2.Data.Models;

namespace TZ_ver2.Data.Interfaces
{
    public interface Idetails
    {
        IEnumerable<Details> Details { get; }
        Details getObjectDetail(int id);
    }
}
