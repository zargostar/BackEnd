namespace SMSService.Api
{
    public class SendSMSService
    {
        public record SendMessageResponse(int id, string Message);
        public async Task<SendMessageResponse> SendSms(int id, CancellationToken cancellationToken)
        {
       
            cancellationToken.ThrowIfCancellationRequested();

            for (int i = 0; i < 10000; i++)
            {

                await Task.Delay(1000, cancellationToken);

                Console.WriteLine($"Hellow {id}");

            }
           
            return new SendMessageResponse(id, $"Hellow {id}");
           

        }
    }
}
