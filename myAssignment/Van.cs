﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAssignment
{
  class Van : Vehicle
  {
    /// <summary>
    /// sets a maximum amount of fuel
    /// gets the current amount of fuel
    /// calls a method FuelType() to generate the right type of fuel for the vehicle
    /// </summary>
    public Van()
    {
      maxFuel = 80;
      currentFuel = random.Next(0, (int)(maxFuel * 0.25f));
      FuelType();
    }

    public override void FuelType()
    {
      int type = random.Next(0, 2);
      switch (type)
      {
        case 0:
        default:
          fuelType = "Diesel";
          break;

        case 1:
          fuelType = "LPG";
          break;
      }
    }

  }
}
