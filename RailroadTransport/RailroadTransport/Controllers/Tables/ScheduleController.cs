using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RailroadTransport.Data;
using RailroadTransport.Models;
using RailroadTransport.ViewModels;

namespace RailroadTransport.Controllers
{
    public class ScheduleController : Controller
    {
        private RailroadContext railroadContext;
        private IMemoryCache cache;
        public ScheduleController(RailroadContext rc, IMemoryCache cache)
        {
            railroadContext = rc;
            this.cache = cache;
        }
        public IActionResult Index(string NameOfBeginStop, string NameOfEndStop, string Stop, TimeSpan StartTime, TimeSpan EndTime, int page = 1)
        {
            ScheduleViewModel viewModel;
            if(!cache.TryGetValue("scheduleViewModel", out viewModel))
            {
                viewModel = SetViewModel(NameOfBeginStop, NameOfEndStop, Stop, StartTime, EndTime, page);
                cache.Set("scheduleViewModel", viewModel);
            }
            else
            {
                if (StartTime.TotalMilliseconds == 0 && viewModel.StartTime.TotalMilliseconds != 0)
                    StartTime = viewModel.StartTime;
                if (EndTime.TotalMilliseconds == 0 && viewModel.EndTime.TotalMilliseconds != 0)
                    EndTime = viewModel.EndTime;
                viewModel = SetViewModel(NameOfBeginStop ?? viewModel.NameOfBeginStop, NameOfEndStop ?? viewModel.NameOfEndStop, Stop ?? viewModel.Stop, StartTime, EndTime, page);
                cache.Set("scheduleViewModel", viewModel);
            }
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
        public IActionResult ClearCache()
        {
            cache.Remove("scheduleViewModel");
            return RedirectToAction("Index");
        }   
        public IEnumerable<Schedule> SortSearch(IEnumerable<Schedule> schedules, string NameOfBeginStop, string NameOfEndStop)
        {
            schedules = schedules.Where(n => n.BeginStop.NameOfStop.Contains(NameOfBeginStop ?? "")).Where(n => n.EndStop.NameOfStop.Contains(NameOfEndStop ?? ""));
            if (!string.IsNullOrEmpty(NameOfEndStop) && !string.IsNullOrEmpty(NameOfEndStop))
                schedules.OrderByDescending(t => t.TimeOfArrive);
            return schedules;
        }
        private ScheduleViewModel SetViewModel(string NameOfBeginStop, string NameOfEndStop, string Stop, TimeSpan StartTime, TimeSpan EndTime, int page = 1)
        {
            IEnumerable<Schedule> schedules;
            ScheduleViewModel model;
            if (page > 1)
            {
                cache.TryGetValue("scheduleViewModel", out model);
                if (model != null)
                    schedules = railroadContext.Schedules.Include(b => b.BeginStop).Include(e => e.EndStop).Where(i => i.ScheduleId > model.Schedules.Last().ScheduleId);
                else
                    schedules = railroadContext.Schedules.Include(b => b.BeginStop).Include(e => e.EndStop);
            }
            else
                schedules = railroadContext.Schedules.Include(b => b.BeginStop).Include(e => e.EndStop);
            schedules = SortSearch(schedules, NameOfBeginStop ?? "", NameOfEndStop ?? "");
            int pageSize = 20;
            int count = schedules.Count();
            int countOfTrain = railroadContext.Schedules.Include(b => b.BeginStop).Where(b => b.BeginStop.NameOfStop.Contains(Stop ?? "")).Where(t => t.TimeOfArrive > StartTime && t.TimeOfArrive < EndTime).Count();
            schedules = schedules.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int countOfStops = railroadContext.Stops.Count();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ScheduleViewModel viewModel = new ScheduleViewModel
            {
                Schedules = schedules,
                PageViewModel = pageViewModel,
                NameOfBeginStop = NameOfBeginStop,
                NameOfEndStop = NameOfEndStop,
                StartTime = StartTime,
                EndTime = EndTime,
                CountOfTrains = countOfTrain,
                Stop = Stop,
                CountOfStops = countOfStops
            };
            return viewModel;
        }
    }
}
