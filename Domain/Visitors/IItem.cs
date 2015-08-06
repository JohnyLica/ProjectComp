namespace Domain.Visitors
{
     public interface IItem
     {
          void Accept(IVisitor visitor);
     }
}