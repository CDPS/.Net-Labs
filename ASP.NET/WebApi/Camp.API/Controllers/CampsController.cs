using Camp.Data.Repository.CampRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Camp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;

        public CampsController(ICampRepository campRepository)
        {
            _campRepository = campRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool includeTalks = false)
        {
            try
            {
                var results = await _campRepository.GetAllCampsAsync(includeTalks);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{moniker}")]
        public async Task<IActionResult> Get(string moniker)
        {
            try
            {
                var results = await _campRepository.GetCampAsync(moniker);
                if (results == null) return NotFound();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByDate(DateTime date, bool includeTalks = false)
        {
            try
            {
                var results = await _campRepository.GetAllCampsByEventDate(date, includeTalks);
                if (results == null) return NotFound();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Entites.Camp camp)
        {
            try
            {
                await _campRepository.Add(camp);
                if(await _campRepository.SaveChanges())
                {
                    return Created($"/api/camps/{camp.Moniker}", camp);
                }
                return Ok(camp);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPut("{moniker}")]
        public async Task<IActionResult> Put(string moniker,Entites.Camp camp)
        {
            try
            {
               var oldCamp = await _campRepository.GetCampAsync(moniker);
               if (oldCamp == null) return NotFound();

                oldCamp.Name = camp.Name;
                oldCamp.Length = camp.Length;
                oldCamp.EventDate = camp.EventDate;

                if(await _campRepository.SaveChanges())
                {
                    return Ok(oldCamp);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("{moniker}")]
        public async Task<IActionResult> Delete(string moniker)
        { 
            try
            {
                var oldCamp = await _campRepository.GetCampAsync(moniker);
                if (oldCamp == null) return NotFound();

                await _campRepository.Remove(oldCamp);
                if (await _campRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }
    }
}
