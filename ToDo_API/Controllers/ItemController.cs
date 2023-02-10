using Microsoft.AspNetCore.Mvc;
using ToDo_API.Tools;
using ToDo_API.Models;
using ToDo_DAL.Interfaces;
using ToDo_DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repo;

        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }

        #region GET
        // GET: api/<ItemController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Item> items = _repo.GetAll();
            return Ok(items);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Item? item = _repo.GetById(id);
            if (item is not null)
                return Ok(item);
            else return BadRequest();
        }
        #endregion

        #region POST
        // POST api/<ItemController>
        [HttpPost]
        public IActionResult Post(CreateItem form)
        {
            Item item = _repo.Create(form.MapItem());
            return Ok(item);
        }
        #endregion

        #region PUT/PATCH
        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        public IActionResult Put(int id, UpdateItem form)
        {
            if (id != form.Id)
                return BadRequest();

            Item? item = _repo.Update(form.MapItem());
            if (item is not null)
                return Ok(item);
            else return BadRequest();
        }

        // PUT api/<ItemController>/toggle/5
        [HttpPut("toggle/{id}")]
        [HttpPatch("toggle/{id}")]
        public IActionResult Put(int id)
        {
            Item? item = _repo.Toggle(id);
            if (item is not null)
                return Ok(item);
            else return BadRequest();
        }
        #endregion

        #region DELETE
        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Item? item = _repo.Delete(id);
            if (item is not null)
                return Ok(item);
            else return BadRequest();
        }
        #endregion
    }
}
