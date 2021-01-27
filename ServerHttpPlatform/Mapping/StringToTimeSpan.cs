using System;
namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Mapping
{
    public static class StringToTimeSpan
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line">should be in format: days;hours;minutes;seconds</param>
        /// <returns></returns>
        public static TimeSpan Convert(string line)
        {
            int days = 0;
            int hours = 0;
            int minutes = 0;
            var seconds = 0;
            var strings = line.Split(';');
            try
            {
                days = System.Convert.ToInt32(strings[0]);
                hours = System.Convert.ToInt32(strings[1]);
                minutes = System.Convert.ToInt32(strings[2]);
                seconds = System.Convert.ToInt32(strings[3]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new TimeSpan(days, hours, minutes, seconds);
            }
            return new TimeSpan(days,hours, minutes, seconds);
        }
    }
}
