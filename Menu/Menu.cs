using System;
using System.Collections.Generic;

namespace WeatherAPI
{
    static public class Menu
    {
        static private bool menuEnabled = true;
        static private bool paramEnabled = true;        

        static private List<string> unselectedParameters = new List<string>();
        static private List<string> selectedParameters = new List<string>();

        static public bool temperature = false;
        static public bool precipitation = false;
        static public bool wind = false;
        static public bool pressure = false;
        static public bool UVindex = false;


        static private void SetParametrs()
        {
            // Adds parametrs to list
            unselectedParameters.Add("Temperature");
            unselectedParameters.Add("Precipitation");
            unselectedParameters.Add("WindSpeed");
            unselectedParameters.Add("Pressure");
            unselectedParameters.Add("UVindex");

            // User selects parameters from a list
            while (paramEnabled)
            {
                Console.WriteLine("Choose parameters:");

                foreach (var param in unselectedParameters) // Show unselected parametrs
                {
                    Console.WriteLine("\t" + param);
                }

                Console.WriteLine("\nSelected:");
                foreach (var param in selectedParameters) // Show selected parametrs
                {
                    Console.WriteLine("\t" + param);
                }

                Console.WriteLine("\n\tReady\n");

                string paramChoice = Console.ReadLine();


                // Remove selected parameters from list and add to selected list
                switch (paramChoice.ToLower())
                {
                    case "temperature":

                        if (unselectedParameters.Contains("Temperature"))
                        {
                            temperature = true;
                            unselectedParameters.RemoveAt(unselectedParameters.IndexOf("Temperature"));
                            selectedParameters.Add("Temperature");
                            break;
                        }
                        temperature = false;
                        selectedParameters.RemoveAt(selectedParameters.IndexOf("Temperature"));
                        unselectedParameters.Add("Temperature");
                        break;


                    case "precipitation":

                        if (unselectedParameters.Contains("Precipitation"))
                        {
                            precipitation = true;
                            unselectedParameters.RemoveAt(unselectedParameters.IndexOf("Precipitation"));
                            selectedParameters.Add("Precipitation");
                            break;
                        }
                        precipitation = false;
                        selectedParameters.RemoveAt(selectedParameters.IndexOf("Precipitation"));
                        unselectedParameters.Add("Precipitation");
                        break;


                    case "windspeed":

                        if (unselectedParameters.Contains("WindSpeed"))
                        {
                            wind = true;
                            unselectedParameters.RemoveAt(unselectedParameters.IndexOf("WindSpeed"));
                            selectedParameters.Add("WindSpeed");
                            break;
                        }
                        wind = false;
                        selectedParameters.RemoveAt(selectedParameters.IndexOf("WindSpeed"));
                        unselectedParameters.Add("WindSpeed");
                        break;


                    case "pressure":

                        if (unselectedParameters.Contains("Pressure"))
                        {
                            pressure = true;
                            unselectedParameters.RemoveAt(unselectedParameters.IndexOf("Pressure"));
                            selectedParameters.Add("Pressure");
                            break;
                        }
                        pressure = false;
                        selectedParameters.RemoveAt(selectedParameters.IndexOf("Pressure"));
                        unselectedParameters.Add("Pressure");
                        break;


                    case "uvindex":

                        if (unselectedParameters.Contains("UVindex"))
                        {
                            UVindex = true;
                            unselectedParameters.RemoveAt(unselectedParameters.IndexOf("UVindex"));
                            selectedParameters.Add("UVindex");
                            break;
                        }
                        UVindex = false;
                        selectedParameters.RemoveAt(selectedParameters.IndexOf("UVindex"));
                        unselectedParameters.Add("UVindex");
                        break;



                    case "ready":

                        if (selectedParameters.Count != 0)
                        {
                            paramEnabled = false;
                            break;
                        }
                        Console.WriteLine("Choose at least one parameter");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Wrong parametr");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }
     

        static public void Show()
        {
            SetParametrs();

            while (menuEnabled)
            {
                Console.WriteLine("\tShow current value - Current");
                Console.WriteLine("\tShow week's value - Week");

                Console.WriteLine("\n\tExit - Exit\n");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice.ToLower())
                {
                    case "current":
                        ShowValue.Current();
                        break;

                    case "week":
                        ShowValue.Week();
                        break;

                    case "exit":
                        menuEnabled = false;
                        break;

                    default:
                        Console.WriteLine("Wrong choose");
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }   
            
        }
    }
}
