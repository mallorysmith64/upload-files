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
        string _incoming;
        public HomeController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            _env = env;
            _incoming = Environment.GetEnvironmentVariable("INCOMING_DIR");
        }
        public IActionResult Index() => View();

        public IActionResult SingleFile(IFormFile file)
        {
            string ts = DateTime.Now.ToString("yyyyMMddHHmmssFFF"); // case sensitive

            using (var fileStream = new FileStream(Path.Combine(_incoming, $"incoming-{ts}.xml"), FileMode.Create, FileAccess.Write))
        {
            file.CopyTo(fileStream);
        }
            return RedirectToAction("Index");
        }
    public IActionResult MultipleFiles(IEnumerable<IFormFile> files)
    {
            foreach (var file in files)
            {
                string ts = DateTime.Now.ToString("yyyyMMddHHmmssFFF"); // case sensitive
                using (var fileStream = new FileStream(Path.Combine(_incoming, $"incoming-{ts}.xml"), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
            }
            return RedirectToAction("Index");
        }    
    }
}