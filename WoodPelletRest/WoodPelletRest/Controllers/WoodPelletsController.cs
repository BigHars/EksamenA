using Microsoft.AspNetCore.Mvc;
using WoodPelletsLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WoodPelletRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletsController : ControllerBase
    {
        private WoodPelletRepository _data;

        public WoodPelletsController(WoodPelletRepository data)
        {
            _data = data;
        }

        // GET: api/<WoodPelletsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<WoodPellet> woodPellets = _data.GetAll();
                return Ok(woodPellets);
            }
            catch (ArgumentException)
            {
                return NoContent();
            }
        }

        // GET api/<WoodPelletsController>/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                WoodPellet woodPellet = _data.GetById(id);
                return Ok(woodPellet);
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<WoodPelletsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] WoodPellet value)
        {
            try
            {
                WoodPellet woodPellet = _data.Add(value);
                return Created("A new wood pellet was created: ", value);
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }

        // PUT api/<WoodPelletsController>/5
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] WoodPellet value)
        {
            try
            {
                WoodPellet woodPellet = _data.Update(id, value);
                return Created("The requested pellet was updated", value);            
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
