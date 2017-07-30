using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Hosting;
using System.Web.Http.SelfHost;
namespace WebApiSelfHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8089");
            var server = new HttpSelfHostServer(config);
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server running");
            Console.ReadLine();
        }
    }
}
