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
        [ValidateNever]
        public IEnumerable<Event> Events { get; set; }

        public Event _event { get; set; } = new Event();

        public DateTime CurrentDate { get; set; } = DateTime.Now;
    }
}
