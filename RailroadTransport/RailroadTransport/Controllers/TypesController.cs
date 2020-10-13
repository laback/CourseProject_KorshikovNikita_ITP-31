using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailroadTransport.Data;

namespace RailroadTransport.Controllers
{
    public class TypesController : Controller
    {
        private RailroadContext rc;
        public TypesController(RailroadContext rc)
        {
            this.rc = rc;
        }
        public IActionResult ShowTable()
        {
            var types = rc.Types;
            return View(types);
        }
    }
}
