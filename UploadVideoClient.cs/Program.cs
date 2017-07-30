using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UploadVideoClient.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var stream = File.Open("small.mp4", FileMode.Open);
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream),@"\video\",@"\video.mp4\");
            var res = client.PostAsync("", content).ContinueWith((r) =>
            {
                r.Result.EnsureSuccessStatusCode();
            });
        }
    }
}
