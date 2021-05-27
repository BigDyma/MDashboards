using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Payment;
using WebAPI.Model.Dto.Reports;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class PaymentController: BaseController
    {
        private IPaymentService _paymentService { get; }
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ReceivePaymentDto token)
        {
            await _paymentService.CreateCharge(token.Token, 3000);
            return Ok();
       }
    }
}
