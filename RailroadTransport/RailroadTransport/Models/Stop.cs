using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.Models
{
    public class Stop
    {
        [Key]
        public int StopId { get; set; }
        public string NameOfStop { get; set; }
        public ICollection<Schedule> ScheduleBeginStop { get; set; }
        public ICollection<Schedule> ScheduleEndStop { get; set; }
    }
}
