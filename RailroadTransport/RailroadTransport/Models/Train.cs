using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.Models
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; }
        public int TypeId { get; set; }
        public bool IsFirm { get; set; }
        public Type Type { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
    }
}
