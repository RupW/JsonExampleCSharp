using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = JsonConvert.DeserializeObject<Root>(File.ReadAllText("genericSample.json"));

            Console.WriteLine("Today's menu");
            Console.WriteLine("------------");
            foreach (var menu in root.Menu)
            {
                Console.WriteLine($"    {menu.DishName,-30} £{menu.Cost}");
            }
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Menu
    {
        [JsonProperty("DishName")]
        public string DishName { get; set; }

        [JsonProperty("Cost")]
        public string Cost { get; set; }
    }

    public class Root
    {
        [JsonProperty("Menu")]
        public List<Menu> Menu { get; set; }
    }
}
