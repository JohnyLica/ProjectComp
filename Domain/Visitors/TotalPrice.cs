using Domain.Domain;

namespace Domain.Visitors
{
     public class TotalPrice : IVisitor

     {
          public decimal Total { set; get; }

          public void Visit(Computer computer)
          {
               Total += computer.Price;
          }

     }
}