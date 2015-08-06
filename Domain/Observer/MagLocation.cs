#region

using System.Collections.Generic;

#endregion

namespace Domain.Observer
{
     public class MagLocation
     {
          private readonly IList<IObserver> _people;
          private string _state;

          public MagLocation()
          {
               _people = new List<IObserver>();
          }

          public string State
          {
               get { return _state; }
               set
               {
                    _state = value;
                    Notify();
               }
          }

          public void Attach(IObserver observer)
          {
               if (!_people.Contains(observer))
               {
                    _people.Add(observer);
               }
          }

          public void Detach(IObserver observer)
          {
               if (_people.Contains(observer))
               {
                    _people.Add(observer);
               }
          }

          public void Notify()
          {
               foreach (var observer in _people)
               {
                    observer.Update(State);
               }
          }
     }
}