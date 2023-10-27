using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherAPI
{
    internal partial class Program
    {               
        static void Main(string[] args)
        {
            Menu.Show();
        }
    }
}
