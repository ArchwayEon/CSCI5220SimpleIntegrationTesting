﻿using System;

namespace MotorVehicleLib
{
   public class Random100 : IRandom
   {
      private readonly Random _random = new Random();

      public int GetNumber()
      {
         return _random.Next(1, 101);
      }
   }
}