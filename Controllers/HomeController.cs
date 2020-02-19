using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace upload_files.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

    [HttpPost("UploadFiles")]
        public static async Task<HttpResponseMessage> Post(string baseUrl, string xmlString)
        {
        using (var httpClient = new HttpClient())
           {
               var httpContent = new StringContent(xmlString, Encoding.UTF8, "text/xml");
               httpContent.Headers.Add("SOAPAction", "http://LAPTOP-5R3N8CS8:9090");
               System.Diagnostics.Debug.Write("async was invoked");
               return await httpClient.PostAsync(baseUrl, httpContent);  
           }
        }
    }
}