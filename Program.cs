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
            var menuRoot = JsonConvert.DeserializeObject<MenuRoot>(File.ReadAllText("genericSample.json"));

            Console.WriteLine("Today's menu");
            Console.WriteLine("------------");
            foreach (var menu in menuRoot.Menu)
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

    public class MenuRoot
    {
        [JsonProperty("Menu")]
        public List<Menu> Menu { get; set; }
    }
}
