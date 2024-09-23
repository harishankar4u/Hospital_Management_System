using Hospitalpage.Infrastructure.Command;
using Hospitalpage.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospitalpage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            //_logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        // Action to open the form
        [HttpGet]
        [Route("AppoinmentForm")]
        public async Task<IActionResult> OpenForm()
        {
            return View(); // Return a new empty model to fill in the form
        }
        //[HttpPost]
        //[Route("AppoinmentForm")]
        //public async Task<IActionResult> OpenForm(Appoinment value)
        //{
        //    return View(new Appoinment());
        //}

    }
}
