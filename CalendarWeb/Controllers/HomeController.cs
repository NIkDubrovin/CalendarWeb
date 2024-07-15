using Calendar.DataAccess.Repository.IRepository;
using Calendar.Models;
using Calendar.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalendarWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            string test = DateTime.Now.ToString("MMMM yyyy");
            string n = DateTime.Now.ToString("MMMM yyyy").TrimEnd();

            CalendarVM calendarVM = new()
            {                
                Events = new List<Event>()
            };

            return View(calendarVM);
        }

        public IActionResult Left(DateTime date)
        {
            CalendarVM calendarVM = new()
            {              
                Events = new List<Event>(),
                CurrentDate = date.AddMonths(-1)
            };

            return View("Index", calendarVM);
        }

        public IActionResult Right(DateTime date)
        {
            CalendarVM calendarVM = new()
            {
                Events = new List<Event>(),
                CurrentDate = date.AddMonths(1)
            };

            return View("Index", calendarVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region API CALLS
        //[HttpGet]
        //public IActionResult Event(int? id)
        //{
        //    Event ev = _unitOfWork.Event.Get(p => p.Id == id);
        //    return Json(new {data = ev});
        //}

        //[HttpDelete]
        //public IActionResult Event(int? id)
        //{
        //    Event ev = _unitOfWork.Event.Get(p => p.Id == id);
        //    return Json(new { data = ev });
        //}

        //[HttpPost]
        //public IActionResult Event(Event ev)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (ev.Id == 0)
        //        {
        //            _unitOfWork.Event.Add(ev);
        //        }
        //        else
        //        {
        //            _unitOfWork.Event.Update(ev);
        //        }

        //        _unitOfWork.Save();
        //        TempData["success"] = "Product created successfully";
        //        return Json(new { data = "success" });
        //    }
        //    else
        //    {
        //        return Json(new { data = "error" });
        //    }
        //}
        #endregion
    }
}
