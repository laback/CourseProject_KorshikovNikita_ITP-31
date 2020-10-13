using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int TraindId { get; set; }
        public string Day { get; set; }
        public int BeginStopId { get; set; }
        public int EndStopId { get; set; }
        public float Distance { get; set; }
        public TimeSpan TimeOfArrive { get; set; }
        public Train Train { get; set; }
        public Stop BeginStop { get; set; }
        public Stop EndStop { get; set; }
    }
}
