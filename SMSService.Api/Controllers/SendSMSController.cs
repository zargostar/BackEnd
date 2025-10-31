using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMSService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendSMSController : ControllerBase
    {
        private readonly SendSMSService sendSMS;
        private readonly ILogger<SendSMSController> logger;
        public SendSMSController(SendSMSService sendSMS, ILogger<SendSMSController> logger)
        {
            this.sendSMS = sendSMS;
            this.logger = logger;
        }
        [HttpGet("send/{id}")]
        public async Task<IActionResult> Send(int id,CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var res = await sendSMS.SendSms(id, cancellationToken);
                return Ok(res);

            }
            catch {
                if (cancellationToken.IsCancellationRequested)
                {;
                    Console.WriteLine("--------------cancelede by client");
                }
                return null;
            }

          
        }
    }
}
