#region

using System;
using System.IO;
using System.Text;
using Domain;
using Domain.Domain;
using Domain.Observer;
using Domain.Visitors;
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

               Console.WriteLine(date2);              
               var productComputers = ProductFactory.CreateNewComputer("Asus", "Intel Core i7", 8, 2, 2013, 500);
               var computer = new NewComputerProxy(new Computer("Asus", "Intel Core i7", 8, 2, 2012,1500));
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
               ObserverPattern();
               Visitors();
               Console.ReadKey();

               
          }

          private static void Visitors()
          {
               var comp1 = new Computer("Lenovo", "Intel i5", 2, 250, 2009, 750);
               var priceVisitor=new TotalPrice();
               comp1.Accept(priceVisitor);
               Console.ForegroundColor = ConsoleColor.DarkYellow;
               Console.WriteLine("The Price is "+ priceVisitor.Total);
          }

          private static void Decorator()
          {
               IColor whiteColor = new StandardColor();
               IColor redColor = new BulletColor(whiteColor);
               IColor blueColor = new ScratchColor(redColor);
               IColor greenColor = new StripeColor(blueColor);
               greenColor.AddColor();
          }

          private static void ObserverPattern()
          {
               var location = new MagLocation();
               var mag1 = new People("Observer_1", location);
               var mag2 = new People("Observer_2", location);

               location.Attach(mag1);
               location.Attach(mag2);
               location.State = "HighWay Street";
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