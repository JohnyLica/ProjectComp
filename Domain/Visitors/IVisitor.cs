using Domain.Domain;

namespace Domain.Visitors
{
     public interface IVisitor
     {
          void Visit(Computer computer);
     }
}