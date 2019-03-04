using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpixAPI.For_Testing;

namespace TpixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //FirstStartTestDataGenerator.GenerateFakeData(); //Only run ONCE!
            //FirstStartTestDataGenerator.GenerateFakePostsForTopics(1, 36, 20);
            return new string[] { "value1", "value2" };
        }
        
    }
}
