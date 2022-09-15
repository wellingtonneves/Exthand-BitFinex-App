using Newtonsoft.Json;
using RestSharp;
using System;

namespace Exthand.Bitfinex.Shared.Helpers.Extensions
{
    public class Converter
    {
        public static long ToEpochStart(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0);
            return (long)(date - origin).TotalMilliseconds;
        }

        public static RestResponse<T> Deserialize<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<dynamic>(response.Content);
        }
    }
}
