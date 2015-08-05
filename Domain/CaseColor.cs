#region

using System;

#endregion

namespace Domain
{
     public interface IColor
     {
          void AddColor();
     }

     public class StandardColor : IColor
     {
          public void AddColor()
          {
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("Standard Color is applied");
          }
     }

     public abstract class AdditionalColor : IColor
     {
          protected IColor Input;

          protected AdditionalColor(IColor i)
          {
               Input = i;
          }

          public abstract void AddColor();
     }

     public class BulletColor : AdditionalColor, IColor
     {
          public BulletColor(IColor i) : base(i)
          {
          }

          public override void AddColor()
          {
               Input.AddColor();
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Bullets are applied");
          }
     }

     public class StripeColor : AdditionalColor, IColor
     {
          public StripeColor(IColor i) : base(i)
          {
          }

          public override void AddColor()
          {
               Input.AddColor();
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.WriteLine("Stripes are applied");
          }
     }

     public class ScratchColor : AdditionalColor, IColor
     {
          public ScratchColor(IColor i) : base(i)
          {
          }

          public override void AddColor()
          {
               Input.AddColor();
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("Scratchs are applied");
          }
     }
}