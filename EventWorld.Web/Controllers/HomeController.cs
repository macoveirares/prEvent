using EventWorld.Services.Services.Events;
using EventWorld.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace EventWorld.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetSliderEvents()
        {
            var events = _eventService.GetFirstThreeUpcomingEvents();
            var eventModels = events.Select(x => new CarouselEventModel
            {
                Id = x.Id,
                Title = x.Title,
                ImagePath = x.ImagePath,
                IsActive = false
            }).ToList();
            eventModels[0].IsActive = true;
            return Json(eventModels);
        }
    }
}
