using LeadTracker.Models;
using LeadTracker.Services;
using System.Web.Http;

namespace LeadTrackerBKM.Controllers
{
    public class InteractionController : ApiController
    {
        [Authorize]
        private InteractionService CreateInteractionService()
        {
            var interactionService = new InteractionService();
            return interactionService;
        }
        
        public IHttpActionResult Put(InteractionEdit interaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInteractionService();

            if (!service.UpdateInteraction(interaction))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int ID)
        {
            InteractionService interactionService = CreateInteractionService();
            var interaction = interactionService.GetInteractionById(ID);
            return Ok(interaction);
        }

        public IHttpActionResult Get()
        {
            InteractionService interactionService = CreateInteractionService();
            var interactions = interactionService.GetInteractions();
            return Ok(interactions);
        }

        public IHttpActionResult Delete(int ID)
        {
            var service = CreateInteractionService();

            if (!service.DeleteInteraction(ID))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Post(InteractionCreate interaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInteractionService();

            if (!service.CreateInteraction(interaction))
                return InternalServerError();

            return Ok();
        }
    }
}
