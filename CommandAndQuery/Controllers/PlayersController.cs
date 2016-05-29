using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web.Http;
using System.Web.Http.Description;
using CommandAndQuery.Command.CommandHandlers;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;
using CommandAndQuery.Mediators;
using MediatR;

namespace CommandAndQuery.Controllers
{
    public class PlayersController : ApiController
    {
        private BasketballContext db = new BasketballContext();
        private IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return db.Players;
        }

        [ResponseType(typeof (Player))]
        public IHttpActionResult GetPlayer(int id)
        {
            var player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [ResponseType(typeof (void))]
        public IHttpActionResult PutPlayer(int id, PlayerEditCommand command)
        {
            _mediator.Send(command);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof (Player))]
        public IHttpActionResult PostPlayer(PlayerCreateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = _mediator.Send(command);

            return CreatedAtRoute("DefaultApi", new {id = player.Id}, player);
        }
    }
}
