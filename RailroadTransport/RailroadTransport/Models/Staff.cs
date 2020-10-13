using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string FIO { get; set; }
        public int TrainId { get; set; }
        public int PostId { get; set; }
        public int Age { get; set; }
        public int WorkExp { get; set; }
        public Post Post { get; set; }
        public Train Train { get; set; }
    }
}
