#region

using System;
using System.IO;
using System.Text;
using Domain;
using Domain.Domain;
using Factories.Factories;
using Infrastructure.IoC;

#endregion

namespace Presentation
{
     public class Client
     {
          private static readonly ComputerFactory ProductFactory;

          public static void Main(string[] args)
          {
               var date2 = DateTime.UtcNow;
               
               Console.WriteLine( date2);
               //var currentTime = DateTime.Now;
               //Console.WriteLine(currentTime);

               var productComputers = ProductFactory.CreateNewComputer("Asus", "Intel Core i7", 8, 2, 2013);
               var computer = new NewComputerProxy(new Computer("Asus", "Intel Core i7", 8, 2, 2012));
               computer.ChangeRam();
               using (var fs = new FileStream("myFile.txt", FileMode.Open))
               {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    const string composite = "Name={0,-5} CPU={1,-15} RAM={2,-5} HDD={3,-5} Year={4, -20}";

                    var bytes = Encoding.ASCII.GetBytes(composite);
                    var bytescount = Encoding.ASCII.GetByteCount(composite);
                    Console.WriteLine(composite, productComputers.NameComp, productComputers.Cpu, productComputers.Ram,
                         productComputers.Hdd, productComputers.Year);
                    fs.Write(bytes, 0, bytescount);
               }
               Decorator();
               Console.ReadKey();
          }

          private static void Decorator()
          {
               IColor whiteColor= new StandardColor();
               IColor redColor=new BulletColor(whiteColor);
               IColor blueColor=new ScratchColor(redColor);
               IColor greenColor=new StripeColor(blueColor);
               greenColor.AddColor();
          }

          static Client()
          {
               ServiceLocator.RegisterAll();
               ProductFactory = ServiceLocator.Get<ComputerFactory>();
          }

          public void Display()
          {
          }
     }
}