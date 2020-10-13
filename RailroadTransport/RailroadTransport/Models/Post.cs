﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string NameOfPost { get; set; }
        public ICollection<Staff> Staff { get; set; }
    }
}
