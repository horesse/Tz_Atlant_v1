using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TZ_ver2.Data;
using TZ_ver2.Data.Interfaces;
using TZ_ver2.Data.Models;
using TZ_ver2.Views.ViewModels;

namespace TZ_ver2.Controllers
{
    public class SkeepersController : Controller
    {
        private AppDBcontent Context { get; }
        private readonly ISkeeper _AllSkeeper;

        public SkeepersController(ISkeeper ISkeeper, AppDBcontent _context)
        {
            _AllSkeeper = ISkeeper;
            this.Context = _context;
        }

        //получение модели для упрощения работы
        public SkeeperListViewModel GetModel()
        {
            var skeeper = _AllSkeeper.AllSkeepers;
            SkeeperListViewModel obj = new SkeeperListViewModel();
            obj.skeeper = _AllSkeeper.AllSkeepers;
            DateTime dt = new DateTime(default);
            List<int> count = new List<int>();
            foreach (var sk in obj.skeeper)
            {
                int id = sk.id;
                var c = this.Context.Details
                    .Where(p => p.SkeeperID == id && p.DeleteDate == dt)
                    .Count();
                count.Add(c);
            }
            obj.count = count;
            return obj;
        }
        public ViewResult Index() //создание основной страницы
        {
            var obj = GetModel();
            return View(obj);
        }

        public ActionResult AddSkeeper(Skeeper skeeper) //функция добавления + валидация
        {
            if (ModelState.IsValid)
            {
                this.Context.Add(skeeper);
                this.Context.SaveChanges();
                return RedirectToAction("index");
            }
            var obj = GetModel();
            return View("index", obj);
        }

        public ActionResult DeleteSkeeper(Skeeper skeeper) //удаление с проверкой
        {
            DateTime dt = new DateTime(default);
            int id = skeeper.id;
            var c = this.Context.Details
                .Where(p => p.SkeeperID == id && p.DeleteDate == dt)
                .Count();
            if (c <= 0)
            {
                this.Context.Skeeper.Remove(skeeper);
                this.Context.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}
