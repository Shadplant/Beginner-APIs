using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace _18_1_22_Beginner_APIs.Controllers
{
    [Route("picture")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public IActionResult GetFile()
        {
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "pictures/cat.jpg");
            string file_type = "application/jpg";
            string file_name = "cat.jpg";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
