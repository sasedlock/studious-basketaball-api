using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Description;
using CommandAndQuery.Command.CommandHandlers;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;
using CommandAndQuery.Mediators;
using CommandAndQuery.Query.QueryHandlers;
using MediatR;

namespace CommandAndQuery.Controllers
{
    public class BasketballTeamsController : ApiController
    {
        private readonly IMediator _mediator;

        public BasketballTeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/BasketballTeams
        //[Route("~api/basketballteams/getall")]
        public IEnumerable<BasketballTeam> GetTeams()
        {
            return _mediator.Send(new GetAllTeamsQuery());
        }

        // GET: api/BasketballTeams/5
        [ResponseType(typeof(BasketballTeam))]
        public IHttpActionResult GetBasketballTeam(int id)
        {
            var query = new GetTeamByIdQuery() { TeamId = id};
            var basketballTeam = _mediator.Send(query);
            if (basketballTeam == null)
            {
                return NotFound();
            }

            return Ok(basketballTeam);
        }

        // PUT: api/BasketballTeams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBasketballTeam(int id, BasketballTeamEditCommand editCommand)
        {
            _mediator.Send(editCommand);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BasketballTeams
        [HttpPost]
        [ResponseType(typeof(BasketballTeam))]
        public IHttpActionResult PostBasketballTeam(BasketballTeamCreateCommand createCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basketballTeam = _mediator.Send(createCommand);

            return CreatedAtRoute("DefaultApi", new { id = basketballTeam.Id }, basketballTeam);
        }

        // DELETE: api/BasketballTeams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBasketballTeam(BasketballTeamDeleteCommand command)
        {
            _mediator.Send(command);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/basketballteams/addplayertoteam")]
        [ResponseType(typeof(BasketballTeam))]
        public IHttpActionResult AddPlayerToTeam(AddPlayerToTeamCommand command)
        {
            var result = _mediator.Send(command);

            return Ok(result);
        }
    }
}