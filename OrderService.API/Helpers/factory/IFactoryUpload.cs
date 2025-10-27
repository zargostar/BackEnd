namespace OrderService.API.Helpers.factory
{
    public interface IFactoryUpload
    {
      
        void Uploader(IFormFile? file);
    }
    public class FactoryUpload : IFactoryUpload
    {
        private readonly string ip;
        private readonly string path;

        public FactoryUpload(string ip, string path,string test)
        {
            this.ip = ip;
            this.path = path;
        }

        public void Uploader(IFormFile? file)
        {
            Console.WriteLine(ip );
        }
    }
}
