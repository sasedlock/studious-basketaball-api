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

        private PlayerEditCommandHandler _editCommandHandler;
        private PlayerCreateCommandHandler _createCommandHandler;

        //private IMediator _mediator;

        //public PlayersController() : this(new BasketballMediator()) { }

        //public PlayersController(BasketballMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        public PlayersController(
            PlayerEditCommandHandler playerEditCommandHandler,
            PlayerCreateCommandHandler playerCreateCommandHandler)
        {
            _editCommandHandler = playerEditCommandHandler;
            _createCommandHandler = playerCreateCommandHandler;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return db.Players;
        }

        //[HttpGet]
        //[Route("~/api/players/test")]
        //public IHttpActionResult Test()
        //{
        //    var result = _mediator.Send(default(IRequest));

        //    return Ok(result);
        //}

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
            _editCommandHandler.Handle(command);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof (Player))]
        public IHttpActionResult PostPlayer(PlayerCreateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = _createCommandHandler.Handle(command);

            return CreatedAtRoute("DefaultApi", new {id = player.Id}, player);
        }
    }
}
