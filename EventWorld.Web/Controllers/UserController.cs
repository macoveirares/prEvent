using EventWorld.Services.Services.Events;
using EventWorld.Services.Services.Users;
using EventWorld.Web.Helpers;
using EventWorld.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using System;
using System.Linq;
using System.Security.Claims;

namespace EventWorld.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;

        public UserController(IUserService userService, IEventService eventService)
        {
            _userService = userService;
            _eventService = eventService;
        }

        public IActionResult UserProfile()
        {
            return View();
        }

        public JsonResult GetUserProfile(long? id)
        {
            var currentUserId = Convert.ToInt64(HttpContext.User.FindFirstValue("Id"));
            id = id ?? currentUserId;
            var user = _userService.GetById(id.Value);
            var userModel = (UserProfileModel)new UserProfileModel().InjectFrom(user);
            userModel.Age = AgeHelper.CalculateAge(user.DateOfBirth);
            var userAttendedEvents = _eventService.GetUserAttendedEvents(id.Value);
            var userAttendedEventsModels = MapperHelper.MapEventsToModels(userAttendedEvents);

            if (id == currentUserId)
            {
                var userEvents = _eventService.GetUserUpcomingEvents(id.Value);
                var userEventsModels = MapperHelper.MapEventsToModels(userEvents);
                return Json(new { userInfo = userModel, userAttendedEvents = userAttendedEventsModels, userEvents = userEventsModels });
            }

            return Json(new { userInfo = userModel, userAttendedEvents = userAttendedEventsModels });
        }

        [HttpPost]
        public JsonResult SubmitFeedback(long eventId, long userId, int rating)
        {
            _userService.SaveFeedback(eventId, userId, rating);
            return Json(true);
        }

        public JsonResult GetUserEnrolledEvents()
        {
            var events = _userService.GetUserEnrolledEvents(Convert.ToInt64(HttpContext.User.FindFirstValue("Id")));
            var eventModels = events.Select(x => (ChatEventModel)new ChatEventModel().InjectFrom(x)).ToList();
            return Json(eventModels);
        }
    }
}