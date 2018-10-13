using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EME.Controllers
{
    public class RequestController : Controller
    {
        [HttpPost]
        public IActionResult Upload()
        {
            var files = HttpContext.Request.Form.Files;
            List<String> paths = new List<String>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine("Images", "img" + DateTime.Now.Ticks + ".png");
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        paths.Add(filePath);
                    }
                }
            }

            JObject name = JObject.Parse(HttpContext.Request.Form["name"]);
            string firstname = name["first"].ToString();
            string middlename = name["middle"].ToString();
            string lastname = name["last"].ToString();

            return Ok();
        }
    }
}