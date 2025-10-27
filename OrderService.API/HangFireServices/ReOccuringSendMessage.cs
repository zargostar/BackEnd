using Hangfire;

namespace OrderService.API.HangFireServices
{
    public class ReOccuringSendMessage
    {
        private readonly ILogger<ReOccuringSendMessage> logger;

        public ReOccuringSendMessage(ILogger<ReOccuringSendMessage> logger)
        {
            this.logger = logger;
        }

        public void SendEmail()
        {
          
            logger.LogError("test jjjjj send Email");


        }
    }
}
