﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EME.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        [IgnoreAntiforgeryToken]
        public ActionResult OnPostSend()
        {
            Console.WriteLine("Test");
            return null;
        }
    }
}
