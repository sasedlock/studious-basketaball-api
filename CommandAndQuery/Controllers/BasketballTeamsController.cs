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
        private BasketballContext db = new BasketballContext();

        private BasketballTeamEditCommandHandler _editCommandHandler = new BasketballTeamEditCommandHandler();
        private BasketballTeamCreateCommandHandler _createCommandHandler = new BasketballTeamCreateCommandHandler();

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

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != basketballTeam.Id)
            //{
            //    return BadRequest();
            //}

            //db.Entry(basketballTeam).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BasketballTeamExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
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