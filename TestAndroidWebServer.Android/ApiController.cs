using Microsoft.AspNetCore.Mvc;

namespace TestAndroidWebServer.Android
{

    [Route("")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        [HttpGet("")]
        public IActionResult GetRoot()
        {
            return Content("ROOT", "application/json");
        }
        [HttpGet("order")]
        public IActionResult GetOrder()
        {
            return Content("ORDER", "application/json");
        }
        [HttpGet("path")]
        public IActionResult GetPath()
        {
            return Content("PATH", "application/json");
        }
        [HttpGet("gettest")]
        public IActionResult GetTestCommunication()
        {
            return Content("GETTestCommunication", "application/json");
        }
        [HttpPost("posttest")]
        public IActionResult PostTestCommunication()
        {

            return Content("POSTTestCommunication", "application/json");
        }

    }
}
