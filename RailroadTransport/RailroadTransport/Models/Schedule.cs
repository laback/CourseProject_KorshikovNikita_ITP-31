using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public double Distance { get; set; }
        public TimeSpan TimeOfArrive { get; set; }
        public Train Train { get; set; }
        public virtual Stop BeginStop { get; set; }
        public virtual Stop EndStop { get; set; }
    }
}
