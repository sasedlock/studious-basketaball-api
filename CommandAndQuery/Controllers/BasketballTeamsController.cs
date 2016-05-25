using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CommandAndQuery.Command.CommandHandlers;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Controllers
{
    public class BasketballTeamsController : ApiController
    {
        private readonly BasketballContext db = new BasketballContext();
        private readonly BasketballTeamEditCommandHandler _editCommandHandler = new BasketballTeamEditCommandHandler();
        private readonly BasketballTeamCreateCommandHandler _createCommandHandler = new BasketballTeamCreateCommandHandler();
        private readonly AddPlayerToTeamCommandHandler _addPlayerToTeamCommandHandler = new AddPlayerToTeamCommandHandler();

        //public BasketballTeamsController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        // GET: api/BasketballTeams
        public IQueryable<BasketballTeam> GetTeams()
        {
            return db.Teams;
        }

        // GET: api/BasketballTeams/5
        [ResponseType(typeof(BasketballTeam))]
        public IHttpActionResult GetBasketballTeam(int id)
        {
            BasketballTeam basketballTeam = db.Teams.Find(id);
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
            _editCommandHandler.Handle(editCommand);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BasketballTeams
        [ResponseType(typeof(BasketballTeam))]
        //public IHttpActionResult PostBasketballTeam(BasketballTeam basketballTeam)
        public IHttpActionResult PostBasketballTeam(BasketballTeamCreateCommand createCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basketballTeam = _createCommandHandler.Handle(createCommand);

            //db.Teams.Add(basketballTeam);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = basketballTeam.Id }, basketballTeam);
        }

        // DELETE: api/BasketballTeams/5
        [ResponseType(typeof(BasketballTeam))]
        public IHttpActionResult DeleteBasketballTeam(int id)
        {
            BasketballTeam basketballTeam = db.Teams.Find(id);
            if (basketballTeam == null)
            {
                return NotFound();
            }

            db.Teams.Remove(basketballTeam);
            db.SaveChanges();

            return Ok(basketballTeam);
        }

        [HttpPost]
        [Route("api/basketballteams/addplayertoteam")]
        [ResponseType(typeof (BasketballTeam))]
        public IHttpActionResult AddPlayerToTeam(AddPlayerToTeamCommand command)
        {
            var result = _addPlayerToTeamCommandHandler.Handle(command);

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BasketballTeamExists(int id)
        {
            return db.Teams.Count(e => e.Id == id) > 0;
        }
    }
}