#region

using System;
using Domain.Domain;
using InterfaceActions.Notify;

#endregion

namespace ActionImplementation.ActionImplementation
{
     public class CallNotification : ISendNotification
     {
          public void Notify(Computer computer)
          {
               var currentDay = DateTime.Today;
               Console.WriteLine(currentDay);
               Console.WriteLine("Make a call: Computer Asus is available in stores." );
          }
     }
}