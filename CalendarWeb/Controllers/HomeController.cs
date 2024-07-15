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
            CalendarVM calendarVM = new()
            {
                Events = _unitOfWork.Event.GetAll()
            };

            return View(calendarVM);
        }

        public IActionResult Left(DateTime date)
        {
            CalendarVM calendarVM = new()
            {              
                Events = _unitOfWork.Event.GetAll(),
                CurrentDate = date.AddMonths(-1)
            };

            return View("Index", calendarVM);
        }

        public IActionResult Right(DateTime date)
        {
            CalendarVM calendarVM = new()
            {
                Events = _unitOfWork.Event.GetAll(),
                CurrentDate = date.AddMonths(1)
            };

            return View("Index", calendarVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
