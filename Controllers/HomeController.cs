using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using upload_files.Models;

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
            using (var fileStream = new FileStream(Path.Combine(dir,"file.png"), FileMode.Create, FileAccess.Write))

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
            var dir = _env.ContentRootPath;
            using (var fileStream = new FileStream(Path.Combine(dir, $"file{i++}.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
        }
        return RedirectToAction("Index");
        }    
    }
}