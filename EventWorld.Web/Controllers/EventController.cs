using EventWorld.DTO;
using EventWorld.Services.Services.Events;
using EventWorld.Services.Services.EventTypes;
using EventWorld.Web.Helpers;
using EventWorld.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Omu.ValueInjecter;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EventWorld.Web.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventTypeService _eventTypeService;
        private readonly IEventService _eventService;

        public EventController(IEventTypeService eventTypeService, IEventService eventService)
        {
            _eventTypeService = eventTypeService;
            _eventService = eventService;
        }

        public IActionResult List()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult ApproveList()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Analytics()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(long id)
        {
            return View();
        }

        public IActionResult ApproveAttends(long id)
        {
            return View();
        }

        public IActionResult Feedback(long id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateEvent(CreateEventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var eventDto = (EventDTO)new EventDTO().InjectFrom(eventModel);
                eventDto.CreatorUserId = Convert.ToInt64(HttpContext.User.FindFirstValue("Id"));
                _eventService.AddEvent(eventDto);
                return Json(true);
            }

            var errors = new StringBuilder();

            foreach (var modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                    errors.AppendLine(error.ErrorMessage);
            }

            return Json(errors.ToString());
        }

        public JsonResult GetEventTypes()
        {
            var eventTypes = _eventTypeService.GetEventTypes();
            return Json(eventTypes.Select(x => (EventTypeModel)new EventTypeModel().InjectFrom(x)).ToList());
        }

        public JsonResult GetEvents(string searchTerm, long categoryId, int listCount, int takeCount = 12)
        {
            var events = _eventService.GetEvents(searchTerm, categoryId, listCount, takeCount);
            var eventModels = MapperHelper.MapEventsToModels(events);

            if (eventModels.Count() > takeCount)
            {
                eventModels.RemoveAt(eventModels.Count() - 1);
                return Json(new { events = eventModels, areMoreEvents = true });
            }

            return Json(new { events = eventModels, areMoreEvents = false });
        }

        public JsonResult GetEvent(long id)
        {
            var eventDto = _eventService.GetById(id);
            var eventModel = (DetailsEventModel)new DetailsEventModel().InjectFrom(eventDto);
            eventModel.Date = eventDto.Date.ToString("dddd, dd MMMM yyyy HH:mm tt");
            eventModel.ImagePath = eventDto.EventType.ImagePath;
            var isUserAttending = _eventService.CheckIfUserAttendsEvent(Convert.ToInt64(HttpContext.User.FindFirstValue("Id")), id);
            return Json(new { currentEvent = eventModel, isUserAttending });
        }

        public JsonResult GetEventsToApprove()
        {
            var eventsToApprove = _eventService.GetEventsToApprove();
            var eventsToApproveModel = MapperHelper.MapEventsToModels(eventsToApprove);
            return Json(eventsToApproveModel);
        }

        [HttpDelete]
        public JsonResult DeleteEvent(long id)
        {
            _eventService.DeleteEvent(id);
            return Json(true);
        }

        [HttpPost]
        public JsonResult AttendEvent(long id)
        {
            _eventService.AttendEvent(Convert.ToInt64(HttpContext.User.FindFirstValue("Id")), id);
            return Json(true);
        }

        [HttpPost]
        public JsonResult ApproveEvent(long id)
        {
            if (Convert.ToBoolean(HttpContext.User.FindFirstValue("IsAdmin")))
            {
                _eventService.ApproveEvent(id);
                return Json(true);
            }
            return Json("You have no rights for this actions!");

        }

        [HttpPost]
        public JsonResult RejectEvent(long id)
        {
            if (Convert.ToBoolean(HttpContext.User.FindFirstValue("IsAdmin")))
            {
                _eventService.DeleteEvent(id);
                return Json(true);
            }
            return Json("You have no rights for this actions!");
        }

        public JsonResult GetUsersThatWantToAttendEvent(long id)
        {
            var users = _eventService.GetEventAttendes(id, false);
            var userModels = MapperHelper.MapUsersToModels(users);
            return Json(userModels);
        }

        public JsonResult GetUsersThatAttendedEvent(long id)
        {
            var users = _eventService.GetEventAttendes(id, true);
            var userModels = MapperHelper.MapUsersToModels(users);
            return Json(userModels);
        }



        [HttpPost]
        public JsonResult ApproveEnrollment(long eventId, long userId)
        {
            _eventService.ApproveEnrollment(eventId, userId);
            return Json(true);
        }

        [HttpPost]
        public JsonResult RejectEnrollment(long eventId, long userId)
        {
            _eventService.RejectEnrollment(eventId, userId);
            return Json(true);
        }

        public JsonResult GetEventsAnalysis()
        {
            var eventsCountByMonth = _eventService.GetEventsCountByMonth();
            return Json(eventsCountByMonth);
        }
    }
}