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
            var menuRoot = JsonConvert.DeserializeObject<MenuRoot>(File.ReadAllText(
                @"C:\Work\Projects\JsonExample2\genericSample.json"));

            Console.WriteLine("Today's menu");
            Console.WriteLine("------------");
            foreach (var menu in menuRoot.Menu)
            {
                Console.WriteLine($"    {menu.DishName,-30} £{menu.Cost}");
            }
        }
    }

    // MenuRoot myDeserializedClass = JsonConvert.DeserializeObject<MenuRoot>(myJsonResponse);
    public class Menu
    {
        [JsonProperty("dishName")]
        public string DishName { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }
    }

    public class MenuRoot
    {
        [JsonProperty("menu")]
        public List<Menu> Menu { get; set; }
    }
}
