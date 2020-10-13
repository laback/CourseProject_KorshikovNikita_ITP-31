using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailroadTransport.Data;

namespace RailroadTransport.Controllers
{
    public class StaffController : Controller
    {
        private RailroadContext rc;
        public StaffController(RailroadContext rc)
        {
            this.rc = rc;
        }
        public IActionResult Index()
        {
            var result = rc.Staffs.Include(p => p.Post).Take(20);
            return View(result);
        }
    }
}
