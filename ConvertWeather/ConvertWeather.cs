using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public class ConvertWeather
    {
        public DateTime date { get; set; }
        public double temperature { get; set; }
        public double precipitation { get; set; }
        public double wind_speed { get; set; }
        public int pressure { get; set; }
        public int UVindex { get; set; }


        public ConvertWeather(DateTime date, double temperature, double precipitation, double wind_speed, int pressure, int UVindex)
        {
            this.date = date;
            this.temperature = temperature;
            this.precipitation = precipitation;
            this.wind_speed = wind_speed;
            this.pressure = pressure;
            this.UVindex = UVindex;
        }

        static public List<ConvertWeather> Сonversion() // Converting DateTime into adequate time indicators
        {
            // Add parameters
            List<Dates> temperature = Data.GetData(Parameters.temperature).data.First().coordinates.First().dates;
            temperature.Remove(temperature.Last()); // Removing an extra element

            List<Dates> precipitation = Data.GetData(Parameters.precipitation).data.First().coordinates.First().dates;
            precipitation.Remove(precipitation.Last()); // Removing an extra element

            List<Dates> wind = Data.GetData(Parameters.wind_speed).data.First().coordinates.First().dates;
            wind.Remove(wind.Last()); // Removing an extra element

            List<Dates> pressure = Data.GetData(Parameters.pressure).data.First().coordinates.First().dates;
            pressure.Remove(pressure.Last()); // Removing an extra element

            List<Dates> UVindex = Data.GetData(Parameters.UVindex).data.First().coordinates.First().dates;
            UVindex.Remove(UVindex.Last()); // Removing an extra element


            List<ConvertWeather> data = new List<ConvertWeather>();

            for (int i = 0; i < temperature.Count; i++)
            {
                int year = Convert.ToInt32(temperature[i].date.ToString().Split('T')[0].Split('-')[0]);
                int month = Convert.ToInt32(temperature[i].date.ToString().Split('T')[0].Split('-')[1]);
                int day = Convert.ToInt32(temperature[i].date.ToString().Split('T')[0].Split('-')[2]);
                int hour = Convert.ToInt32(temperature[i].date.ToString().Split('T')[1].Split(':')[0]);


                data.Add(new ConvertWeather(new DateTime(year, month, day, hour, 0, 0), temperature[i].value, precipitation[i].value, wind[i].value, Convert.ToInt32(pressure[i].value), Convert.ToInt32(UVindex[i].value)));              
            }          
                return data;
        }       

        public override string ToString()
        {
            return date.ToString();
        }
    }
}
