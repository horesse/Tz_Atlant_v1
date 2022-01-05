using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TZ_ver2.Data.Interfaces;
using TZ_ver2.Data.Models;

namespace TZ_ver2.Data.Repos
{
    public class SkeeperRepos : ISkeeper
    {
        private readonly AppDBcontent AppDBcontent;

        public SkeeperRepos(AppDBcontent AppDBcontent)
        {
            this.AppDBcontent = AppDBcontent;
        }
        public IEnumerable<Skeeper> AllSkeepers => AppDBcontent.Skeeper;
    }
}
