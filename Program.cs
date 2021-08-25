using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JsonExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
