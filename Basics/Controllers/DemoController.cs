using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Basics.Controllers
{
    public class DemoController:ApiController
    {
        private List<int> data = new List<int>
        {
            1,
            2,
            3
        };

        public IEnumerable<int> Get()
        {
            return data;
        }

        public int Get(int index)
        {
            return data[index];
        }

        public void Post([FromBody] int value)
        {
            data.Add(value);
        }
    }
}