using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;

namespace Fedsearch
{
    class Program
    {
        public static string query { get; set; }
        public static int count { get; set; }
        public static string APIContent { get; set; }
        public static string API_KEY { get; set; }
        static void Main(string[] args)
        {
            // API KEY HERE.
            API_KEY = "1948";

            // Load banner
            Menu.Banner();

            while (true)
            {
            Start:
                count = 0;

                Console.Write($"{Color.Blue} Search query: {Color.Reset}"); query = Console.ReadLine();

                // Commands
                switch (query)
                {
                    case "!clear":
                    case "!cls":
                        Console.Clear();
                        Menu.Banner();
                        goto Start;

                    case "!exit":
                        Environment.Exit(0);
                        break;
                }

                // Send HTTP Post Request to API
                APIContent = API.Request(query);

                switch (APIContent)
                {
                    // No results found
                    case string a when a.Contains("No Results Found"):
                        Console.WriteLine("\n No Results Found!\n");
                        goto Start;

                    // Handle null error
                    case null:
                        Console.WriteLine("\n Error occured while d eserialization\n");
                        goto Start;
                }

                try
                {
                    // Deserialize JSON Response
                    var resp = JsonConvert.DeserializeObject<List<Json>>(APIContent);

                    // Output results
                    foreach (var item in resp)
                    {
                        count++;
                        Console.WriteLine($"\n{Color.Yellow} ╔══════════════════════>{Color.Reset}");
                        Console.WriteLine($" {Color.Yellow} {Color.Cyan} ID: {item.id}");
                        Console.WriteLine($" {Color.Yellow} {Color.Cyan} IP: {item.ip}");
                        Console.WriteLine($" {Color.Yellow} {Color.Cyan} Email: {item.email}");
                        Console.WriteLine($" {Color.Yellow} {Color.Cyan} Password: {item.password}");
                        Console.WriteLine($" {Color.Yellow} {Color.Cyan} Token: {item.token}");
                        Console.WriteLine($" {Color.Yellow} {Color.Cyan} Database: {item.database}");
                        Console.WriteLine($" {Color.Yellow}╚══════════════════════>\n{Color.Reset}");
                    }
                }
                catch { Console.WriteLine("\n Error occured!\n"); goto Start; }

                // Results counter
                Console.WriteLine(" Results found: " + count + "\n");
            }
        }
    }
}
