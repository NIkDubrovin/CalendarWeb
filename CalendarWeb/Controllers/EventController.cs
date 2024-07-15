using Bulky.DataAccess.Repository;
using Calendar.DataAccess.Repository.IRepository;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalendarWeb.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<EventController>
        [HttpGet]
        public IActionResult Get()
        {
            var events = _unitOfWork.Event.GetAll();
            if(events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Event ev = _unitOfWork.Event.Get(p => p.Id == id);
            if (ev == null)
            {
                return NotFound();
            }
            return Ok(ev);
        }

        // POST api/<EventController>
        [HttpPost]
        public IActionResult Post([FromBody] Event value)
        {
            if (ModelState.IsValid)
            {            
                _unitOfWork.Event.Add(value);
                _unitOfWork.Save();
               // TempData["success"] = "Event created successfully";
                return Ok(value);
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }  
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {

        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
