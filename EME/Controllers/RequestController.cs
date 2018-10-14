using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EME.Objects;
using EME.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EME.Controllers
{
    public class RequestController : Controller
    {
        [HttpPost]
        public object[] Upload()
        {
            try
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

                User u = new User();

                JObject name = JObject.Parse(HttpContext.Request.Form["name"]);
                u.FirstName = name["first"].ToString();
                u.MiddleName = name["middle"].ToString();
                u.LastName = name["last"].ToString();

                u.ImagePaths = paths;

                return SearchService.PreformSearch(u);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}