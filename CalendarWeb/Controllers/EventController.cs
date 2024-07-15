using Bulky.DataAccess.Repository;
using Calendar.DataAccess.Repository.IRepository;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                var oldValue = _unitOfWork.Event.Get(e => e.Id == id);  
                if (oldValue == null)
                {
                    return NotFound();
                }

                oldValue.Title = value.Title;
                oldValue.Date = value.Date;
                oldValue.Color = value.Color;

                _unitOfWork.Event.Update(value);
                _unitOfWork.Save();
                
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

            Event? ev = _unitOfWork.Event.Get(c => c.Id == id);
            if (ev == null)
            {
                return NotFound();
            }
            _unitOfWork.Event.Remove(ev);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
