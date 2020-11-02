using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailroadTransport.ViewModels
{
    public class FilterPostViewModel
    {
        [Display(Name = "Код должности")]
        public int PostId { get; set; }
        [Display(Name = "Название должности")]
        public string NameOfPost { get; set; }
    }
}
