using System;
using System.Globalization;
using Domain.Domain;
using InterfaceActions.Notify;

namespace ActionImplementation.ActionImplementation
{
     public class EmailNotification : ISendNotification
     {
          public void Notify(Computer computer)
          {
               var ukInfo= CultureInfo.GetCultureInfo("en-GB");            
               Console.WriteLine("Send Email: Computer Lenovo is available in stores.");
               Console.WriteLine("Its cost "+300.ToString("C", ukInfo));
               
          }
     }
}
