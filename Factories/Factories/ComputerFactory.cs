using Domain.Domain;
using InterfaceActions.Notify;

namespace Factories.Factories
{
     public class ComputerFactory
     {
          private readonly ISendNotification _actionSendNotification;

          public ComputerFactory(ISendNotification actionSendNotification)
          {
               _actionSendNotification = actionSendNotification;
          }

          public void OnProductCreation (Computer product)
          {
               _actionSendNotification.Notify(product);
          }

          public  Computer CreateNewComputer(string name, string cpu, int ram, float hdd, int year)
          {
               var computer = new Computer(name, cpu, ram, hdd, year);
               OnProductCreation(computer);
               return computer;
          }

          public  Computer CreateNewLaptop(string name, int ram, float hdd, int year)
          {
               var laptop = new Computer(name, " ", ram, hdd, year);
               OnProductCreation(laptop);
               return laptop;
          }
     }
}