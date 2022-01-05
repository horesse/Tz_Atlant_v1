using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TZ_ver2.Data.Interfaces;
using TZ_ver2.Data.Models;

namespace TZ_ver2.Data.Repos
{
    public class DetailsRepos : Idetails
    {
        private readonly AppDBcontent AppDBcontent;

        public DetailsRepos(AppDBcontent AppDBcontent) {
            this.AppDBcontent = AppDBcontent;
        }

        //public IEnumerable<Details> Details => throw new NotImplementedException();

        public IEnumerable<Details> Details => AppDBcontent.Details.Include(c => c.Skeeper);

        public Details getObjectDetail(int id) => AppDBcontent.Details.FirstOrDefault(p => p.id == id);
    }
}
