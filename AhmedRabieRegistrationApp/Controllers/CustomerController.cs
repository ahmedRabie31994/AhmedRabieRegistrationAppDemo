using AhmedRabieRegistrationApp.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace AhmedRabieRegistrationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }

        [HttpPost("set-pin")]
        public async Task<IActionResult> SetPin(SetPinCommand request)
        {
            bool pinResult = await _mediator.Send(request);
            if (!pinResult)
            return BadRequest(new { Message = "Email or mobile not verified." });
            return Ok("updated successfully");
        }

        [HttpPost("{customerId}/verify-email")]
        public async Task<IActionResult> VerifyEmail(int customerId,string otp)
        {
            // Simulate email verification process
            //check OTP is VALID
            // Update customer status
            bool validOTP = otp == "1234"; //simulated Value
            if (!validOTP)
            {
                return BadRequest("not valid otp");
            }
            VerifyOtpCommand command = new VerifyOtpCommand()
            {
                CustomerId = customerId,
                OTP = otp,
                VerificationType = VerificationType.Email
            };
           await _mediator.Send(command);
            return Ok("successfully verified Email");
        }

        [HttpPost("{customerId}/verify-mobile")]
        public async Task<IActionResult> VerifyMobile(int customerId,string otp)
        {
            // Simulate mobile verification process
            //check OTP is VALID
            // Update customer status
            bool validOTP = otp == "1234"; //simulated Value
            if (!validOTP)
            {
                return BadRequest("not valid otp");
            }
            VerifyOtpCommand command = new VerifyOtpCommand()
            {
                CustomerId = customerId,
                OTP = otp,
                VerificationType = VerificationType.MobileNumber
            };
            await _mediator.Send(command);
            return Ok("successfully verified mobile Number");
        }

        [HttpPost("{customerId}/EnableBiometric")]
        public async Task<IActionResult> EnableBiometric(int customerId)
        {
            // Simulate mobile verification process
            //check OTP is VALID
            // Update customer status
            EnableBiometricCommand command = new EnableBiometricCommand()
            {
                CustomerId = customerId, 
            };
             await _mediator.Send(command);
            return Ok($"Biometric Enabled For customer ID {customerId}");
        }
    }
}
