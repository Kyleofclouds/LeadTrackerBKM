﻿using LeadTracker.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeadTracker.Models
{
    public class InteractionDetail
    {
        public int InteractionID { get; set; }
        public int LeadID { get; set; }
        public int RepID { get; set; }
        [Display(Name = "Type of Contact")]
        public ContactType TypeOfContact { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
