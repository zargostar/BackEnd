using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSService.Api.ApiService;
using SMSService.Api.ApiService.BackGroundService;

namespace SMSService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendSMSController : ControllerBase
    {
        private readonly SendSMSService sendSMS;
        private readonly SuplierApiService suplierApiService;
        private readonly ILogger<SendSMSController> logger;
        private readonly IBackgroundTaskQueue _queue;
        public SendSMSController(SendSMSService sendSMS, ILogger<SendSMSController> logger, SuplierApiService suplierApiService, IBackgroundTaskQueue queue)
        {
            this.sendSMS = sendSMS;
            this.logger = logger;
            this.suplierApiService = suplierApiService;
            _queue = queue;
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
        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            //await suplierApiService.Get();
            _queue.QueueWork(async token =>
            {
                await suplierApiService.Get();
            });
            return NoContent();
        }
    }
}
