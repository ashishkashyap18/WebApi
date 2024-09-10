using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurHeroController : ControllerBase
    {
        private readonly IOurHeroService _heroService;

        public OurHeroController(IOurHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_heroService.GetAllHeros(isActive));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var hero = _heroService.GetOurHeroById(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post(AddUpdateOurHero heroObj)
        {
            var hero = _heroService.AddOurHero(heroObj);
            if (hero == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateOurHero heroObj)
        {
            var hero = _heroService.UpdateOurHero(id, heroObj);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Super Hero Updated successfully",
                id = hero!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_heroService.DeleteOurHeroById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Super hero deleted successfully",
                id = id
            });
        }
    }
}
