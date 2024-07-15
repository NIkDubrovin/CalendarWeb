using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Models.ViewModels
{
    public class CalendarVM
    {
        public IEnumerable<Event> Events { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public DateTime CurrentDate { get; set; } = DateTime.Now;
    }
}
