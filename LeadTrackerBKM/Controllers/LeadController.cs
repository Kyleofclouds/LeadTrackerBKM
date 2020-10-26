using LeadTracker.Models;
using LeadTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeadTrackerBKM.Controllers
{
    [Authorize]
    public class LeadController : ApiController
    {
        private LeadService CreateLeadService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var leadService = new LeadService();//NoteService(userId);
            return leadService;
        }
        public IHttpActionResult Get()
        {
            LeadService leadService = CreateLeadService();
            var leads = leadService.GetLeads();
            return Ok(leads);
        }
        public IHttpActionResult Post(LeadCreate lead)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLeadService();

            if (!service.CreateLead(lead))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            LeadService leadService = CreateLeadService();
            var lead = leadService.GetLeadByID(id);
            return Ok(lead);
        }
        public IHttpActionResult Put(LeadEdit lead)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLeadService();

            if (!service.UpdateLead(lead))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateLeadService();

            if (!service.DeleteLead(id))
                return InternalServerError();

            return Ok();
        }
    }
}
