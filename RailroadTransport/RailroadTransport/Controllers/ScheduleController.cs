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
    public class ScheduleController : Controller
    {
        private RailroadContext railroadContext;
        public ScheduleController(RailroadContext rc)
        {
            railroadContext = rc;
        }
        public IActionResult Index(int page = 1)
        {
            IEnumerable<Schedule> schedules = railroadContext.Schedules.Include(b => b.BeginStop).Include(e => e.EndStop);
            int pageSize = 20;
            int count = schedules.Count();
            schedules = schedules.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Schedules = schedules,
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["TrainId"] = new SelectList(railroadContext.Trains, "TrainId", "TrainId");
            ViewData["BeginStopId"] = new SelectList(railroadContext.Stops, "StopId", "NameOfStop");
            ViewData["EndStopId"] = new SelectList(railroadContext.Stops, "StopId", "NameOfStop");
            return View();
        }
        public IActionResult Create([Bind("ScheduleId,TrainId,Day,BeginStopId,EndStopId,Distance, TimeOfArrive")] Schedule schedule)
        {
            if (schedule.Distance > 0)
            {
                railroadContext.Schedules.Add(schedule);
                railroadContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["TrainId"] = new SelectList(railroadContext.Trains, "TrainId", "TrainId");
            ViewData["BeginStopId"] = new SelectList(railroadContext.Stops, "StopId", "NameOfStop");
            ViewData["EndStopId"] = new SelectList(railroadContext.Stops, "StopId", "NameOfStop");
            return View(schedule);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var staff = railroadContext.Schedules.Find(id);
            ViewData["BeginStopId"] = new SelectList(railroadContext.Stops, "StopId", "NameOfStop");
            ViewData["EndStopId"] = new SelectList(railroadContext.Stops, "StopId", "NameOfStop");
            ViewData["TrainId"] = new SelectList(railroadContext.Trains, "TrainId", "TrainId");
            return View(staff);
        }
        public IActionResult Edit([Bind("ScheduleId,TrainId,Day,BeginStopId,EndStopId,Distance, TimeOfArrive")] Schedule schedule)
        {
            railroadContext.Update(schedule);
            railroadContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            var result = railroadContext.Schedules.Include(b => b.BeginStop).Include(e => e.EndStop).Where(s => s.ScheduleId == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleConfirmed(int id)
        {
            var schedule = railroadContext.Schedules.Find(id);
            railroadContext.Schedules.Remove(schedule);
            railroadContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
