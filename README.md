Reading a JSON file in C# using Json2CSharp to generate data classes
--------------------------------------------------------------------

1. Create a new .NET console project in Visual Studio or Rider, or at the command prompt
   ```
    dotnet new console
   ```
   (If you're using VS then either .NET Framework or .NET Core or .NET 5+ is fine)

2. (Optional but a good habit!) Make a git repository
   ```
   dotnet new gitignore
   git add .
   git commit -a -m "Initial commit"
   ```

3. Add Newtonsoft.Json, the de-facto .NET JSON library.
   1. In Visual Studio
      1. right-click the project name and "Manage NuGet packages"   
         (or Tools, NuGet Package Manager, Manage NuGet Packages for Solution)
      2. Browse, Newtonsoft.Json; in the right-hand panel, Install
   2. Using the dotnet command line tool
      ```
      dotnet add package Newtonsoft.Json 
      ```

4. Generate typed classes for our example JSON file
   1. Use either the online tool at [https://json2csharp.com](https://json2csharp.com/) or the offline version [from GitHub](https://github.com/Json2CSharp/Json2CSharpCodeGenerator).
      * The two are equivalent: they use the same code generation engine. For this data it's OK to use the website but for real work we should avoid posting real project data to strange websites!)
      * You might want to tick "Add JsonProperty Attributes" if you're using the website to get PascalCase C# property names. This is on by default in the offline version.
   2. For now let's just put the code it generated into Program.cs, in the namespace but below the Program class:
      ```c#
      // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
      public class Menu
      {
          [JsonProperty("dishName")]
          public string DishName { get; set; }

          [JsonProperty("cost")]
          public string Cost { get; set; }
      }

      public class Root
      {
          [JsonProperty("menu")]
          public List<Menu> Menu { get; set; }
      }
      ```
      You'll need to add two `using` statements too to the top of the file (or use the suggested VS or Rider actions to do this automatically):
      ```c#
      using Newtonsoft.Json;
      using System.Collections.Generic;
      ```
      Note that it has given you the Newtonsoft.Json command you'll need to deserialize a string into these structures in a comment.
   3. Let's rename the top level class from Root to MenuRoot to avoid a clash if we add more JSON to this program:
      ```c#
      // MenuRoot myDeserializedClass = JsonConvert.DeserializeObject<MenuRoot>(myJsonResponse); 
      public class Menu
      {
          [JsonProperty("dishName")]
          public string DishName { get; set; }

          [JsonProperty("cost")]
          public string Cost { get; set; }
      }

      public class MenuRoot
      {
          [JsonProperty("menu")]
          public List<Menu> Menu { get; set; }
      }
      ```
   4. and let's add code to read in the JSON file and deserialize it into our structure in the Main() method, using the example it gave us plus `File.ReadAllText()` to read the whole file into a string:
      ```c#
      var menuRoot = JsonConvert.DeserializeObject<MenuRoot>(
          File.ReadAllText("genericSample.json"));
      ```
      Again you'll need another `using` at the top:
      ```c#
      using System.IO;
      ```
      **Note**: if you're using Visual Studio or Rider then it will default to starting the program in the directory it has compiled it into, which will be two or three directories below your project directory.
      There are several ways of solving this but for now it's probably simplest to give the full path to the file here, e.g.
      ```c#
      var menuRoot = JsonConvert.DeserializeObject<MenuRoot>(
          File.ReadAllText(@"c:\work\speedcoding2021\jsonexample\genericSample.json"));
      ```
      If you're using the `dotnet` command at the console then it will read from the current directory so you won't have to do this.
   
5. Finally let's do something with the data we've read:
   ```c#
   Console.WriteLine("Today's menu");
   Console.WriteLine("------------");
   foreach (var menu in menuRoot.Menu)
   {
       Console.WriteLine($"    {menu.DishName,-30} £{menu.Cost}");
   }
   ```
   and run the project from the IDE, or `dotnet run` from the console.
