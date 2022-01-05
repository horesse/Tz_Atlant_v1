using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TZ_ver2.Controllers;
using TZ_ver2.Data.Models;

namespace TZ_ver2.Data
{
    public class DBObjects
    {
        public static void initial(AppDBcontent content)
        {
            if (!content.Skeeper.Any())
                content.Skeeper.AddRange(Skeepers.Select(c => c.Value));

            if (!content.Details.Any())
            {
                content.AddRange(
                    new Details { 
                        Num_code = "f1",
                        name = "test1",
                        count = 1
                        //Skeeper = "test1"
                    },
                    new Details
                    {
                        Num_code = "f2",
                        name = "test2",
                        count = 5
                    },
                    new Details
                    {
                        Num_code = "f4",
                        name = "test3",
                        count = 5
                    },
                    new Details
                    {
                        Num_code = "f3",
                        name = "test3",
                        count = 7
                    }
                );
            }
            
            content.SaveChanges();
        }

        /*public static void AddDetail(Details detail, AppDBcontent content)
        {
            content.AddRange(
                    new Details
                    {
                        Num_code = detail.Num_code,
                        name = detail.name,
                        count = detail.count,
                        Skeeper = detail.Skeeper,
                        CreateDate = detail.CreateDate
                    });
            
            content.SaveChanges();
        } */

        public static void Add(AppDBcontent content)
        {
            content.Add(
                    new Details
                    {
                        Num_code = "We are stuped",
                        name = "debil",
                        count = 7,
                        CreateDate = DateTime.Now,
                        DeleteDate = DateTime.Now
                    }
                );

            content.SaveChanges();
        }

        public static void Delete(AppDBcontent content)
        {
            //AppDBcontent content;

            content.Update(
                new Details
                {
                    id = 2,
                    DeleteDate = DateTime.Now
                });

            content.SaveChanges();
        }

        private static Dictionary<string, Skeeper> skeeper;
        public static Dictionary<string, Skeeper> Skeepers
        {
            get
            {
                if (skeeper == null)
                {
                    var list = new Skeeper[]
                    {
                        new Skeeper { name = "test" },
                        new Skeeper { name = "test2"}
                    };

                    skeeper = new Dictionary<string, Skeeper>();
                    foreach (Skeeper el in list)
                        skeeper.Add(el.name, el);

                }
                return skeeper;
            }
        }
    }
}
