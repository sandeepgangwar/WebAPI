using JSONPDemo.Controllers;
using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace JSONPDemo
{
    internal class MyJSONPFormatter : MediaTypeFormatter
    {
        public MyJSONPFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/javascript"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(JOSNPReturn);
        }

        public override Task WriteToStreamAsync(Type type, 
            object value, 
            Stream writeStream, 
            HttpContent content, 
            TransportContext transportContext)
        {
            return Task.Factory.StartNew(()=>
            {
                var jsonp = (JOSNPReturn)value;
                var sw = new StreamWriter(writeStream, UTF8Encoding.Default);
                sw.Write("{0}({1});", jsonp.CallBack, jsonp.JSON);
                sw.Flush();
            });
        }
    }
}