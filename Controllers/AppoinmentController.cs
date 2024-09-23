using Hospitalpage.Infrastructure.Command;
using Hospitalpage.Infrastructure.Query;
using Hospitalpage.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospitalpage.Controllers
{
    public class AppoinmentController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public AppoinmentController( IMediator mediator)
        {
            //_logger = logger;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppoinment(Appoinment value)
        {

            if (ModelState.IsValid)
            {
               var resp= await _mediator.Send(new CretaeAppoinmentCommand(value));
                return RedirectToAction("Index", "Home"); // Redirect to a confirmation page or another appropriate actions
            }

            return View("OpenForm", value);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppoinment()
        {
            var resp = await _mediator.Send(new GetAppoinmentQuery());
            return View(resp);
        }
    }
}
