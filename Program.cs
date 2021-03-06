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
            var menuRoot = JsonConvert.DeserializeObject<MenuRoot>(
                File.ReadAllText("genericSample.json"));

            Console.WriteLine("Today's menu");
            Console.WriteLine("------------");
            foreach (var item in menuRoot.Menu)
            {
                Console.WriteLine($"    {item.DishName,-30} £{item.Cost}");
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
