using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RailroadTransport.Data;
using RailroadTransport.Models;
using RailroadTransport.ViewModels;

namespace RailroadTransport.Controllers
{
    public class TrainController : Controller
    {
        private RailroadContext railroadContext;
        public TrainController(RailroadContext rc)
        {
            railroadContext = rc;
        }
        public IActionResult Index(int page = 1)
        {
            IEnumerable<Train> trains = railroadContext.Trains.Include(t => t.Type);
            int pageSize = 20;
            int count = trains.Count();
            trains = trains.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Trains = trains,
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(railroadContext.Types, "TypeId", "NameOfType");
            ViewData["IsFirm"] = new string[] { "True", "False" };
            return View();
        }
        public IActionResult Create([Bind("TrainId,TypeId,IsFirm")] Train train)
        {
            if (ModelState.IsValid)
            {
                railroadContext.Add(train);
                railroadContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["TypeId"] = new SelectList(railroadContext.Types, "TypeId", "NameOfType",train.TypeId);
            ViewData["IsFirm"] = new string[] { "True", "False" };
            return View(train);
        }
    }
}
