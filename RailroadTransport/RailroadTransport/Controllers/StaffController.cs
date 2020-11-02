using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RailroadTransport.Data;
using RailroadTransport.Models;
using RailroadTransport.ViewModels;

namespace RailroadTransport.Controllers
{
    public class StaffController : Controller
    {
        private RailroadContext railroadContext;
        public StaffController(RailroadContext rc)
        {
            railroadContext = rc;
        }
        public IActionResult Index(int page = 1)
        {
            IEnumerable<Staff> staffs = railroadContext.Staffs.Include(p => p.Post).Include(t => t.Train).OrderBy(s => s.StaffId);
            int pageSize = 20;
            int count = staffs.Count();
            staffs = staffs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Staffs = staffs,
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["TrainId"] = new SelectList(railroadContext.Trains, "TrainId", "TrainId");
            ViewData["PostId"] = new SelectList(railroadContext.Posts, "PostId", "NameOfPost");
            return View();
        }
        public IActionResult Create([Bind("StaffId,FIO,TrainId,PostId,Age,WorkExp")] Staff staff)
        {
            if (staff.PostId > 0 && staff.TrainId > 0 && staff.Age > 0 && staff.WorkExp > 0 && staff.FIO != null)
            {
                railroadContext.Staffs.Add(staff);
                railroadContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["TrainId"] = new SelectList(railroadContext.Trains, "TrainId", "TrainId", staff.TrainId);
            ViewData["PostId"] = new SelectList(railroadContext.Posts, "PostId", "NameOfPost", staff.PostId);
            return View(staff);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var staff = railroadContext.Staffs.Find(id);
            ViewData["TrainId"] = new SelectList(railroadContext.Trains, "TrainId", "TrainId", staff.TrainId);
            ViewData["PostId"] = new SelectList(railroadContext.Posts, "PostId", "NameOfPost", staff.PostId);
            return View(staff);
        }
        public IActionResult Edit([Bind("StaffId,FIO,TrainId,PostId,Age,WorkExp")] Staff staff)
        {
            railroadContext.Update(staff);
            railroadContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            var staff = railroadContext.Staffs.Include(p => p.Post).Where(s => s.StaffId == id).FirstOrDefault();
            return View(staff);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleConfirmed(int id)
        {
            var staff = railroadContext.Staffs.Find(id);
            railroadContext.Staffs.Remove(staff);
            railroadContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IEnumerable<Staff> SortSearch(IEnumerable<Staff> staffs, int Age, int WorkExp, string FIO, string NameOfPost, SortState sortState)
        {
            switch(sortState)
            {
                case SortState.AgeAcs:
                    staffs = staffs.OrderBy(a => a.Age);
                    break;
                case SortState.AgeDecs:
                    staffs = staffs.OrderByDescending(a => a.Age);
                    break;
                case SortState.WorkExpAcs:
                    staffs = staffs.OrderBy(w => w.WorkExp);
                    break;
                case SortState.WorkExpDecs:
                    staffs = staffs.OrderByDescending(w => w.WorkExp);
                    break;
                case SortState.FIOAcs:
                    staffs = staffs.OrderBy(f => f.FIO);
                    break;
                case SortState.FIODecs:
                    staffs = staffs.OrderByDescending(f => f.FIO);
                    break;
                case SortState.NameOfPostAcs:
                    staffs = staffs.OrderBy(n => n.Post.NameOfPost);
                    break;
                case SortState.NameOfPostDesc:
                    staffs = staffs.OrderByDescending(n => n.Post.NameOfPost);
                    break;
            }
            staffs = staffs.Where(a => a.Age );
        }
    }
}
