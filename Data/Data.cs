using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public struct Parameters
    {
        public const string temperature = "t_2m:C"; // Temperature
        public const string precipitation = "precip_1h:mm"; // Precipitation
        public const string wind_speed = "wind_speed_10m:ms"; // Wind speed
        public const string pressure = "msl_pressure:hPa"; // Mean sea level pressure
        public const string UVindex = "uv:idx"; // Level of ultraviolet radiation in the spectrum of sunlight
    }


    static public class Data
    {
        // User
        private const string username = "mx____";
        private const string password = "aqtU1F4X18";

        static public Weather GetData(string param) // Receive temperature data from https://meteomatics.com
        {

            // Url           
            DateTime date = DateTime.Now;
            string url = $"https://api.meteomatics.com/{date.Year}-{date.Month}-{date.Day}T00:00:00Z--{date.AddDays(7).Year}-{date.AddDays(7).Month}-{date.AddDays(7).Day}T00:00:00Z:PT1H/{param}/46.390890,30.724842/json";

            try
            {
                // Connecting
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "application/json";

                // Authorization
                string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
                request.Headers["Authorization"] = "Basic " + credentials;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("Failed : HTTP error code : " + response.StatusCode);
                }

                // GetContent
                string content;

                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    content = streamReader.ReadToEnd();
                }


                return JsonConvert.DeserializeObject<Weather>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

    }
}
