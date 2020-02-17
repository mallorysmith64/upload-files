using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace upload_files.Controllers
{
    public class HomeController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;
        private string _dir;
        public HomeController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IActionResult Index() => View();

        public IActionResult SingleFile(IFormFile file)
        {
            using (var fileStream = new FileStream(Path.Combine(_dir,"file.png"), FileMode.Create, FileAccess.Write))

        {
            file.CopyTo(fileStream);
        }
            return RedirectToAction("Index");
        }
    public IActionResult MultipleFiles(IEnumerable<IFormFile> files)
    {
        int i = 0;
        foreach (var file in files)
        {
            using (var fileStream = new FileStream(Path.Combine(_dir, $"file{i++}.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
        }
        return RedirectToAction("Index");
        }    
    }
}