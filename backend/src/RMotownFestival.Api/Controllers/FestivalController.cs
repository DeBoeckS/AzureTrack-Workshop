using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

using RMotownFestival.Api.Data;
using RMotownFestival.Api.Domain;
using RMotownFestival.DAL;

namespace RMotownFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        private readonly MotowDbContext _context;
        private readonly TelemetryClient _telemetryClient;
        public FestivalController(MotowDbContext context, TelemetryClient client)
        {
            _context = context;
            _telemetryClient = client;
        }

        [HttpGet("LineUp")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Schedule))]
        public ActionResult GetLineUp()
        {
            return Ok(FestivalDataSource.Current.LineUp);
        }

        [HttpGet("Artists")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Artist>))]
        public ActionResult GetArtists(bool? withRatings)
        {
            if(withRatings.HasValue && withRatings.Value)
            {
                _telemetryClient.TrackEvent("List of artists with ratings");
            }
            else
            {
                _telemetryClient.TrackEvent("List of artists without ratings");
            }
            return Ok(_context.Artists);
        }

        [HttpGet("Stages")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Stage>))]
        public ActionResult GetStages()
        {
            return Ok(_context.Stages);
        }

        [HttpPost("Favorite")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ScheduleItem))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult SetAsFavorite(int id)
        {
            var schedule = FestivalDataSource.Current.LineUp.Items
                .FirstOrDefault(si => si.Id == id);
            if (schedule != null)
            {
                schedule.IsFavorite = !schedule.IsFavorite;
                return Ok(schedule);
            }
            return NotFound();
        }

    }
}