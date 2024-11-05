
using System;
using VRC.SDKBase;

namespace IwacchiLab.Utils
{
    public static class TimeUtility
    {
        public static DateTime ConvertUtcToJst(DateTime utcDateTime)
        {
            // UTCから9時間追加してJSTに変換
            return utcDateTime.AddHours(9);
        }
        
        public static DateTime GetJstTime()
        {
            var utc = Networking.GetNetworkDateTime();
            return ConvertUtcToJst(utc);
        }
    }
}
