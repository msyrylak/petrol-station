﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAssignment
{
  class Stats
  {
    private const double PRICE = 2;
    private static int unleadedDispensed = 0;
    private static int dieselDispensed = 0;
    private static int lpgDispensed = 0;
    private static double totalEarned = 0.0;
    private static int toDispense;
    private static double commission;
    private static int vehiclesServiced = 0;
    private static int numberOfVehiclesCreated = 0;
    private static int numberOfVehiclesGone = 0;


    // accessors for the private variables

    public static double price
    {
      get
      {
        return PRICE;
      }
    }

    public static int UnleadedDispensed
    {
      get
      {
        return unleadedDispensed;
      }
      set
      {
        unleadedDispensed = value;
      }
    }

    public static double TotalEarned
    {
      get
      {
        return totalEarned;
      }
      set
      {
        totalEarned = value;
      }
    }

    public static double Commission
    {
      get
      {
        return commission;
      }
      set
      {
        commission = value;
      }
    }

    public static int ToDispense
    {
      get
      {
        return toDispense;
      }
      set
      {
        toDispense = value;
      }
    }

    public static int DieselDispensed
    {
      get
      {
        return dieselDispensed;
      }
      set
      {
        dieselDispensed = value;
      }
    }

    public static int LPGDispensed
    {
      get
      {
        return lpgDispensed;
      }
      set
      {
        lpgDispensed = value;
      }
    }

    public static int VehiclesServiced
    {
      get
      {
        return vehiclesServiced;
      }
      set
      {
        vehiclesServiced = value;
      }
    }

    public static int VehiclesCreated
    {
      get
      {
        return numberOfVehiclesCreated;
      }
      set
      {
        numberOfVehiclesCreated = value;
      }
    }

    public static int VehiclesGone
    {
      get
      {
        return numberOfVehiclesGone;
      }
      set
      {
        numberOfVehiclesGone = value;
      }
    }

    /// <summary>
    /// method that shows all the counters
    /// </summary>
    public static void ShowStats()
    {
      Console.WriteLine("Queue: {0,-5}".PadLeft(42), Program.vehicleLine.Count);
      Console.WriteLine("Number of vehicles created: {0,-5}".PadLeft(42), VehiclesCreated);
      Console.WriteLine("Number of vehicles serviced so far: {0,-5}".PadLeft(40), VehiclesServiced);
      Console.WriteLine("Number of vehicles gone: {0,-5}".PadLeft(42), VehiclesGone);
      Console.WriteLine("Unleaded dispensed: {0,-5}".PadLeft(42), UnleadedDispensed);
      Console.WriteLine("Diesel dispensed: {0,-5}".PadLeft(42), DieselDispensed);
      Console.WriteLine("LPG dispensed: {0,-5}".PadLeft(42), LPGDispensed);
      Console.WriteLine("Total earned: {0,-5:0.00}".PadLeft(47), TotalEarned);
      Console.WriteLine("Commission: {0,-5:0.00}".PadLeft(47), Commission);
      Console.WriteLine();
      Console.WriteLine(String.Format("Fuel price: {0,-5:C}".PadLeft(44), price));
    }
  }
}
