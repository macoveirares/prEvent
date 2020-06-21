using System;

namespace EventWorld.Web.Helpers
{
    public static class AgeHelper
    {
        public static string CalculateAge(DateTime birthday)
        {
            DateTime currentDate = DateTime.Now;

            TimeSpan difference = currentDate.Subtract(birthday);

            DateTime age = DateTime.MinValue + difference;

            int ageInYears = age.Year - 1;

            return ageInYears + " Years old";
        }
    }
}
