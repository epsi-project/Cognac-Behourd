using System;
namespace Cognac_Behourd.Class.Extensions
{
    public static class DateExtension
    {
        public static int GetAge(this DateTime dateTime)
        {
            return DateTime.Today.Year - dateTime.Year -
                     (DateTime.Today.Month < dateTime.Month ? 1 :
                     DateTime.Today.Day < dateTime.Day ? 1 : 0);
        }
    }
}
