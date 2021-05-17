using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Models
{
    public class Payment: EntityBase
    {
        public long? SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public long PaymentDetailsId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}
