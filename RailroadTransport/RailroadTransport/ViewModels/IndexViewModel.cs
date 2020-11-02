using RailroadTransport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; } 
        public IEnumerable<Staff> Staffs { get; set; }
        public IEnumerable<Stop> Stops { get; set; }
        public IEnumerable<Models.Type> Types { get; set; }
        public IEnumerable<Train> Trains { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public string NameOfPost { get; set; }
        public string NameOfStop { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
