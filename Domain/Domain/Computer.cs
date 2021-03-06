﻿#region

using System;
using Domain.Visitors;

#endregion

namespace Domain.Domain
{
     public class Computer : IItem
     {
          public Computer(string comp, string cpu, int ram, float hdd, int year, int price)
          {
               if (string.IsNullOrEmpty(comp))
               {
                    throw new ArgumentException("Name of Computer is required.");
               }
               if (string.IsNullOrEmpty(cpu))
               {
                    throw new ArgumentException("PC cannot function without CPU");
               }

               NameComp = comp;
               Cpu = cpu;
               Ram = ram;
               Hdd = hdd;
               Year = year;
               Price = price;
          }

          public string NameComp { get; private set; }
          public string Cpu { get; private set; }
          public int Ram { get; private set; }
          public float Hdd { get; private set; }
          public int Year { get; private set; }
          public int Price { get; private set; }

          public void Accept(IVisitor visitor)
          {
               visitor.Visit(this);
          }
     }

     public interface IComputer
     {
          void ChangeRam();
     }

     public class ComputerProxy : IComputer
     {
          private readonly Computer _computer;
          private readonly IComputer _realComputer;

          public ComputerProxy(Computer computer)
          {
               _computer = computer;
               _realComputer = new RealComputer();
          }

          public void ChangeRam()
          {
               if (_computer.Year < 2010)
                    Console.WriteLine("Computer is old to change Ram to DDR4");
               else
               {
                    _realComputer.ChangeRam();
               }
          }
     }

     public class NewComputer
     {
          public void NewestComputer()
          {
               Console.WriteLine("Changing Ram to DDR4 is successful done");
          }
     }

     public class NewComputerProxy : IComputer
     {
          private readonly Computer _computer;
          private readonly NewComputer _newComputer = new NewComputer();

          public NewComputerProxy(Computer computer)
          {
               _computer = computer;
          }

          public void ChangeRam()
          {
               if (_computer.Year > 2011)
                    _newComputer.NewestComputer();
               else
               {
                    Console.WriteLine("You cannot change Ram to DDR4");
               }
          }
     }

     public class RealComputer : IComputer
     {
          public void ChangeRam()
          {
               Console.WriteLine("Newest Computer");
          }
     }
}