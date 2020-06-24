using EventWorld.DTO;
using EventWorld.Web.Models;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;

namespace EventWorld.Web.Helpers
{
    public static class MapperHelper
    {
        public static List<ListEventModel> MapEventsToModels(List<EventDTO> events)
        {
            return events.Select(x =>
           {
               var eventModel = (ListEventModel)new ListEventModel().InjectFrom(x);
               eventModel.Date = x.Date.ToString("dddd, dd MMMM yyyy HH:mm tt");
               return eventModel;
           }).ToList();
        }

        public static List<UserAttendModel> MapUsersToModels(List<UserDTO> users)
        {
            return users.Select(x =>
            {
                var userModel = (UserAttendModel)new UserAttendModel().InjectFrom(x);
                userModel.Age = AgeHelper.CalculateAge(x.DateOfBirth);
                return userModel;
            }).ToList();
        }
    }
}
