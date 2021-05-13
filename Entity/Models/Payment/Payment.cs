using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Models
{
    public class Payment: EntityBase
    {
        public uint? SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public uint PaymentDetailsId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}
