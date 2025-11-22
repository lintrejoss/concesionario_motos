using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Asp_Presentacion.Pages.Emergentes
{
    public class Mensajes : PageModel
    {
        private readonly ILogger<Mensajes> _logger;

        public Mensajes(ILogger<Mensajes> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}