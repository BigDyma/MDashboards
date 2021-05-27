using Entity;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService(IRepository<PaymentDetails> repositoryPD, IRepository<Payment> repositoryPayment, IRepository<Entity.Models.Subscription> repositorySub, IUserRepository _userRepository, UserManager<User> userManager)
        {
            //RepositoryPD = repositoryPD;
            //RepositoryPayment = repositoryPayment;
            //RepositorySub = repositorySub;
            //userRepository = _userRepository;
            //_userManager = userManager;
        }

        //private IRepository<PaymentDetails> RepositoryPD { get; }
        //private IRepository<Payment> RepositoryPayment { get; }
        //private IRepository<Entity.Models.Subscription> RepositorySub { get; }

        //private IUserRepository userRepository { get; }
        //private UserManager<User> _userManager { get; }
        public async Task CreateCharge(string token, int amount)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    Source = token,
                    Description = "My First Test Charge (created for API docs)",
                };
                var service = new ChargeService();
                service.Create(options);

                // here is very very ugly code but it's 12:48 AM so I have the permission of the gods.

                //var paymentDetails = new PaymentDetails { Amount = amount, PaymentDate = DateTime.Now, PaymentMethod = "stripe" };

                //var subscription = new Entity.Models.Subscription { PlanId = 1, SubscriptionStartTimestamp = DateTime.Now, UserId = userId };

                //await RepositorySub.Create(subscription);

                //await RepositoryPD.Create(paymentDetails);

                //var currentUser = await _userManager.FindByIdAsync(userId.ToString());

                //var roleResult = await _userManager.AddToRoleAsync(currentUser, "Customer");

            }
            catch (StripeException e)
            {
                return;
            }
        }
    }
}
