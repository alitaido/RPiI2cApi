using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unosquare.RaspberryIO;

namespace RPiAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("buttons/state")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var Dev2 = Pi.I2C.AddDevice(0x22);
            var Dev3 = Pi.I2C.AddDevice(0x23);

            return new string[] { $"0x{Dev2.ReadAddressByte(0x12):X2}", $"0x{Dev2.ReadAddressByte(0x13):X2}",
                                  $"0x{Dev2.ReadAddressByte(0x12):X2}", $"0x{Dev2.ReadAddressByte(0x13):X2}" };
        }

        // GET api/values/5
        [HttpGet("i2c/devices")]
        public ActionResult<string> Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            // List registered devices on the I2C Bus
            foreach (var device in Pi.I2C.Devices)
            {
                sb.AppendLine($"Registered I2C Device: {device.DeviceId}");
            }
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
