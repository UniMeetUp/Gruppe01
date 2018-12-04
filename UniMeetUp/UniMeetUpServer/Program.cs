using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace UniMeetUpServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://192.168.87.112:5000", "http://localhost:5000")
                .UseStartup<Startup>();
    }
}
