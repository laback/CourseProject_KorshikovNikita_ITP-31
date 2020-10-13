using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailroadTransport.Data;

namespace RailroadTransport.Controllers
{
    public class ScheduleController : Controller
    {
        private RailroadContext rc;
        public ScheduleController(RailroadContext rc)
        {
            this.rc = rc;
        }
        public IActionResult ShowTable()
        {
            var schedules = rc.Schedules.Include(s => s.BeginStop).Include(se => se.EndStop).ToList();
            return View(schedules);
        }
    }
}
