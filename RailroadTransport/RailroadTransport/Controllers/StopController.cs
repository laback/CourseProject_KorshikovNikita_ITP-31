using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailroadTransport.Data;

namespace RailroadTransport.Controllers
{
    public class StopController : Controller
    {
        private RailroadContext rc;
        public StopController(RailroadContext rc)
        {
            this.rc = rc;
        }
        public IActionResult ShowTable()
        {
            var stops = rc.Stops;
            return View(stops);
        }
    }
}
