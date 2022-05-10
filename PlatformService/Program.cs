using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PlatformService
{

    public class Person : ICloneable
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public object Clone()
        {
            return new Person
            {
                Age = this.Age,
                Name = this.Name
            };
        }

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, options);
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {

            Person p1 = new Person()
            {
                Age = 21,
                Name = "王二"
            };

            //Person p2 = new Person()
            //{
            //    Age = 23,
            //    Name = "李四"
            //};
            //Person p2 = p1;//只复制了引用地址，改变一个 另一个也会改变值

            Person p2 = (Person)p1.Clone();

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            p1.Name = "李四";
            p1.Age = 23;

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.ReadKey();


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
