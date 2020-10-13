using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailroadTransport.Data;
using RailroadTransport.Models;

namespace RailroadTransport.Controllers
{
    public class PostController : Controller
    {
        private RailroadContext rc;
        public PostController(RailroadContext rc)
        {
            this.rc = rc;
        }
        public IActionResult ShowTable()
        {
            var posts = rc.Posts;
            return View(posts);
        }
    }
}
