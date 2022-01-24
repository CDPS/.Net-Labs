using Camp.Data.Repository.CampRepository;
using Camp.Data.Repository.SpeakerRepository;
using Camp.Data.Repository.TalkRepository;
using Camp.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Camp.API.Controllers
{
    [Route("api/camps/{moniker}/talks")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        private readonly ICampRepository _campRepository;
        private readonly ITalkRepository _talksRepository;
        private readonly ISpeakerRepository _speakerRepository;

        public TalksController(ICampRepository campRepository,
                               ITalkRepository talksRepository,
                               ISpeakerRepository speakerRepository)
        {
            _campRepository = campRepository;
            _talksRepository = talksRepository;
            _speakerRepository = speakerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string moniker)
        {
            try
            {
                var results = await _talksRepository.GetTalksByMonikerAsync(moniker);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string moniker, int id)
        {
            try
            {
                var results = await _talksRepository.GetTalkByMonikerAsync(moniker,id);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(string moniker,Talk talk)
        {
            try
            {
                var camp = await _campRepository.GetCampAsync(moniker);
                if (camp == null) return NotFound();

                talk.Camp = camp;

                var speaker = await _speakerRepository.GetSpeakerAsync(talk.Speaker.SpeakerId);
                if(speaker == null) return BadRequest();

                talk.Speaker = speaker;
                await _talksRepository.Add(talk);
                
                if (await _talksRepository.SaveChanges())
                {
                    return Created($"/api/camps/{talk.TalkId}", talk);
                }
                return Ok(talk);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string moniker, int id)
        {
            try
            {
                var talk = await _talksRepository.GetTalkByMonikerAsync(moniker,id);
                if (talk == null) return NotFound();

                await _talksRepository.Remove(talk);

                if (await _talksRepository.SaveChanges())
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
