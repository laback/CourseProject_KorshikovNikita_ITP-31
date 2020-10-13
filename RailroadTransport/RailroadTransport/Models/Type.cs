using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.Models
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }
        public string NameOfType { get; set; }
        public ICollection<Train> Train { get; set; }
    }
}
