using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public  class PaymentRepository : SQLGenericRepository<PaymentDetails>
    {
        public PaymentRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task CreatePayment(PaymentDetails paymentDetails)
        {
            await base.Create(paymentDetails);
        }


    }
}
