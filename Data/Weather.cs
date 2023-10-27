using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public class Weather
    {
        public string version { get; set; }
        public string user { get; set; }
        public string dateGenerated { get; set; }
        public string status { get; set; }
        public List<Options> data { get; set; }

    }

    public class Options
    {
        public string parameter { get; set; }
        public List<Coordinates> coordinates { get; set; }

    }

    public class Coordinates
    {
        public string lat { get; set; }
        public string lon { get; set; }
        public List<Dates> dates { get; set; }
    }

    public class Dates
    {
        public string date { get; set; }
        public double value { get; set; }
    }

}
