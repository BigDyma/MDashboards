using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Models
{
    public class Subscription: EntityBase
    {
        public uint UserId { get; set; }
        public virtual User Customer { get; set; }
        public uint? PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        [Required]
        public DateTime SubscriptionStartTimestamp { get; set; }
        [Required]
        public DateTime SubscriptionEndTimestamp { get; set; }
        [NotMapped]
        public bool IsActive { get => DateTime.Compare(SubscriptionStartTimestamp, SubscriptionEndTimestamp) <= 0; }

    }
}
