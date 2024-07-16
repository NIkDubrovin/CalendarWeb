using Bulky.DataAccess.Repository;
using Calendar.DataAccess.Repository.IRepository;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calendar.BLL;

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
            var events = EventBLLHandler.GetEventList(_unitOfWork);

            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Event ev = EventBLLHandler.GetEvent(_unitOfWork, p => p.Id == id);
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
                EventBLLHandler.AddEvent(_unitOfWork, value);
                return Ok(value);
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }  
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult PutEvent(int id, [FromBody] Event value)
        {
            if (ModelState.IsValid)
            {
                if (id != value.Id)
                {
                    return BadRequest();
                }

                var oldValue = EventBLLHandler.GetEvent(_unitOfWork, p => p.Id == id); 
                if (oldValue == null)
                {
                    return NotFound();
                }

                oldValue.Title = value.Title;
                oldValue.Date = value.Date;
                oldValue.Color = value.Color;

                EventBLLHandler.UpdateEvent(_unitOfWork, oldValue);
                
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Event? ev = EventBLLHandler.GetEvent(_unitOfWork, c => c.Id == id);
            if (ev == null)
            {
                return NotFound();
            }

            EventBLLHandler.Delete(_unitOfWork, ev);

            return Ok();
        }
    }
}
