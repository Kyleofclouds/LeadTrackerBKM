using LeadTracker.Data.Entities;
using LeadTracker.Models;
using LeadTrackerBKM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadTracker.Services
{
    public class InteractionService
    {
        //private readonly Guid _userId;

        //public NoteService(Guid userId)
        //{
            //_userId = userId;
        //}
        public bool CreateInteraction(InteractionCreate model)
            {
            var entity =
                new Interaction()
                {
                    //OwnerId = _userId,
                    LeadID = model.LeadID,
                    RepID = model.RepID,
                    TypeOfContact = model.TypeOfContact,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Interactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InteractionListItem> GetInteractions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Interactions
                        //.Where(e => e.ID == _userId)
                        .Select(
                            e =>
                                new InteractionListItem
                                {
                                    InteractionID = e.InteractionID,
                                    LeadID = e.LeadID,
                                    RepID = e.RepID,
                                    TypeOfContact = e.TypeOfContact,
                                    Description = e.Description,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc,
                                    Lead = e.Lead,
                                    Rep = e.Rep
                                }
                        );

                return query.ToArray();
            }
        }

        public InteractionDetail GetInteractionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionID == id);
                        //.Single(e => e.ID == id && e.OwnerId == _userId);
                return
                    new InteractionDetail
                    {
                        InteractionID = entity.InteractionID,
                        LeadID = entity.LeadID,
                        RepID = entity.RepID,
                        TypeOfContact = entity.TypeOfContact,
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateInteraction(InteractionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionID == model.InteractionID);
                        //.Single(e => e.ID == id && e.OwnerId == _userId);

                entity.TypeOfContact = model.TypeOfContact;
                entity.Description = model.Description;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInteraction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionID == id);
                        //.Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Interactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
