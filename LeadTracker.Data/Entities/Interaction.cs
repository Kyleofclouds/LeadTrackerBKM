using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Data.Entities
{
    public class Interaction
    {
        [Key]
        public Guid ID { get; set; }
        [ForeignKey(nameof(Lead))]
        public int LeadID { get; set; }
        public virtual Lead Lead { get; set; }
        [ForeignKey(nameof(Rep))]
        public int RepID { get; set; }
        public virtual Rep Rep { get; set; }
    }
}
