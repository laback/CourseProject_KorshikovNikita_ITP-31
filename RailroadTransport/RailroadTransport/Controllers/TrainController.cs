using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailroadTransport.Data;

namespace RailroadTransport.Controllers
{
    public class TrainController : Controller
    {
        private RailroadContext rc;
        public TrainController(RailroadContext rc)
        {
            this.rc = rc;
        }
        public IActionResult ShowTable()
        {
            var trains = rc.Trains.Include(t => t.Type);
            return View(trains);
        }
    }
}
