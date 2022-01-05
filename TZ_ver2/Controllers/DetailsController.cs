using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using TZ_ver2.Data;
using TZ_ver2.Data.Interfaces;
using TZ_ver2.Data.Models;
using TZ_ver2.Views.ViewModels;

namespace TZ_ver2.Controllers
{
    public class DetailsController : Controller
    {
        private AppDBcontent Context { get; }

        private readonly Idetails _AllDetails;
        private readonly ISkeeper _AllSkeeper;
         
        public DetailsController(Idetails IDetails, ISkeeper ISkeeper, AppDBcontent _context)
        {
            _AllDetails = IDetails;
            _AllSkeeper = ISkeeper;
            this.Context = _context;
        }

        public DetailsListViewModel getModel()
        {
            DetailsListViewModel obj = new DetailsListViewModel();
            obj.AllDetails = _AllDetails.Details;
            obj.currSkeeper = _AllSkeeper.AllSkeepers;
            return obj;
        }

        [HttpGet]
        public ActionResult Index()
         {
            var obj = getModel();
            ViewBag.Skeepers = new SelectList(this.Context.Skeeper, "id", "name");
            return View(obj);
         }

        [HttpPost]
        public ActionResult AddDetail(Details details)
        {
            if (ModelState.IsValid)
            {
                this.Context.Add(new Details
                {
                    id = details.id,
                    name = details.name,
                    Num_code = details.Num_code,
                    count = details.count,
                    CreateDate = details.CreateDate,
                    SkeeperID = details.SkeeperID
                });;
                this.Context.SaveChanges();
                return RedirectToAction("index");
            }

            var obj = getModel();
            ViewBag.Skeepers = new SelectList(this.Context.Skeeper, "id", "name");
            return View("index", obj);
        }

        [HttpPost]
        public IActionResult DeleteDetail(Details details, int id)
        {
            this.Context.Update(new Details
            {
                id = details.id,
                name = details.name,
                Num_code = details.Num_code,
                count = details.count,
                CreateDate = details.CreateDate,
                SkeeperID = details.SkeeperID,
                DeleteDate = DateTime.Today
            }) ;
            this.Context.SaveChanges();
            ViewBag.id = "id" + id;
            return RedirectToAction("index");
        }
    }
}
