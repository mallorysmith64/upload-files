using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace upload_files.Controllers
{
    public class HomeController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;
        public HomeController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index() => View();

        public IActionResult SingleFile(IFormFile file)
        {
            var dir = _env.ContentRootPath;

            using (var fileStream = new FileStream(Path.Combine(dir, "file.png"), FileMode.Create, FileAccess.Write))
        {
            file.CopyTo(fileStream);
        }
            return RedirectToAction("Index");
        }
    }
}