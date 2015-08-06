#region

using System;

#endregion

namespace Domain.Observer
{
     public class People : IObserver
     {
          private readonly MagLocation _magLocation;
          private readonly string _street;
          private string _state;

          public People(string street, MagLocation magLocation)
          {
               _magLocation = magLocation;
               _street = street;
          }

          public void Update(string state)
          {
               _state = _magLocation.State;
               Console.WriteLine("{0} The Shop  new location is {1}", _street, _state);
          }
     }
}