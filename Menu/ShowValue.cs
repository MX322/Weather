using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI
{
    static public class ShowValue
    {
        static public void Current() // Show current weather data
        {
            List<ConvertWeather> data = ConvertWeather.Сonversion();

            foreach (var d in data)
            {
                if (d.date == new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0))
                {

                    Console.Write($"{DateTime.Now.DayOfWeek}:");

                    if (Menu.temperature)
                    {
                        Console.Write($"  temperature - {d.temperature}°C");
                    }

                    if (Menu.precipitation)
                    {
                        Console.Write($"  precipitation - {d.precipitation}mm");
                    }

                    if (Menu.wind)
                    {
                        Console.Write($"  wind speed - {d.wind_speed}m/s");
                    }

                    if (Menu.pressure)
                    {
                        Console.Write($"  pressure - {d.pressure}hPa");
                    }

                    if (Menu.UVindex)
                    {
                        Console.Write($"  UV index - {d.UVindex}");
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }


        static public void Week() // Show weather data for a week
        {
            List<ConvertWeather> data = ConvertWeather.Сonversion();

            foreach (var d in data)
            {
                for (int i = 0; i <= 7; i++) // Show data at intervals of 3 hours
                {
                    if (d.date.Hour == i * 3)
                    {
                        Console.Write(d.date.DayOfWeek + " {0:D2}", d.date.Hour);

                        if (Menu.temperature)
                        {
                            Console.Write("  temperature - " + "{0:F1}", d.temperature);
                            Console.Write("°C");
                        }

                        if (Menu.precipitation)
                        {
                            Console.Write("  precipitation - " + "{0:F1}", d.precipitation);
                            Console.Write("mm");
                        }

                        if (Menu.wind)
                        {
                            Console.Write("  wind speed - " + "{0:F1}", d.wind_speed);
                            Console.Write("m/s");
                        }

                        if (Menu.pressure)
                        {
                            Console.Write($"  pressure - {d.pressure}");
                            Console.Write("hPa");
                        }

                        if (Menu.UVindex)
                        {
                            Console.Write($"  UV index - {d.UVindex}");
                        }

                        Console.WriteLine();
                    }
                }

                if (d.date.Hour == 21)
                {
                    Console.WriteLine("\n");
                }
            }

            Console.WriteLine();
        }

    }
}
