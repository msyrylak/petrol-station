﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace myAssignment
{
  class Pump
  {
    // variables declaration
    public static Random random = new Random();
    private const double SPEED = 1.5;
    public enum PumpState { Empty, Busy, Ended };
    public PumpState pState = PumpState.Empty;
    private int id;
    private Vehicle current;
    private static string fType;
    private static string vehicleName;

    // constructor accepting an id for a pump
    public Pump(int _id)
    {
      id = _id;
    }

    // return pump state
    public PumpState GetState()
    {
      return pState;
    }

    /// <summary>
    /// this method manages the pumps line 
    /// switch statement checks the state of a pump and 
    /// if the pump is empty it dequeues a vehicle from the line, changes the state to busy and starts timer (fueling time)
    /// if the state is busy then it returns with no action
    /// with ended state it records all information needed for the counters, calls method RecordTransactions() and changes state back to empty
    /// </summary>
    public void PumpManager()
    {
      switch (pState)
      {
        case PumpState.Empty:
        default:
          try
          {
            if (Program.vehicleLine.Count() > 0)
            {
              pState = PumpState.Busy; // change state of a pump to busy
              current = Program.vehicleLine.First();
              Program.vehicleLine.Remove(current);
              double workTime = current.HowMuchFuelNeeded() / SPEED; // fuel time
              vehicleName = current.GetType().Name;
              Stats.ToDispense = current.HowMuchFuelNeeded();
              fType = current.fuelType;
              current.vState = Vehicle.State.Fueling;
              PumpTimer(workTime);
              Utils.refresh = true;
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine("Error: {0}", ex.ToString());
          }
          break;

        case PumpState.Busy:
          break;

        case PumpState.Ended:
          FuelCounters();
          Stats.TotalEarned += Stats.ToDispense * Stats.price;
          Stats.Commission += 0.01 * Stats.TotalEarned;
          RecordTransactions();
          Stats.VehiclesServiced++;
          pState = PumpState.Empty;
          Utils.refresh = true;
          break;
      }
    }

    // timer for the pumps
    void PumpTimer(double interval)
    {
      Timer FuelTimer = new Timer();
      FuelTimer.AutoReset = false;
      FuelTimer.Interval = interval * 1000;
      FuelTimer.Enabled = true;
      FuelTimer.Elapsed += PumpBusy;
    }

    // event that manages the timer
    private void PumpBusy(object sender, ElapsedEventArgs e)
    {
      pState = PumpState.Ended;
    }

    /// <summary>
    /// method used to record all transactions performed at the pumps
    /// it appends to a text file writing all the important informations:
    /// ID of a pump, vehicle type and number of litres dispensed while the vehicle was being served
    /// </summary>
    public void RecordTransactions()
    {
      int dispensed = Stats.ToDispense;

      try
      {
        //https://msdn.microsoft.com/en-us/library/6ka1wd3w(v=vs.110).aspx
        String filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\fuelling_transactions.txt";
        StreamWriter sw = new StreamWriter(filePath, append: true);
        sw.WriteLine("{0} | Pump {1}: {2}, litres dispensed: {3}", DateTime.Now, id + 1, vehicleName, dispensed);
        sw.WriteLine("----------");
        sw.Close();

      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: Pump {0} had a problem with file operation! {1}", id + 1, ex.ToString());
        System.Threading.Thread.Sleep(2000);
      }
    }

    /// <summary>
    /// method that sorts out based on fuel type which counter 
    /// to use
    /// </summary>
    public void FuelCounters()
    {
      switch (fType)
      {
        case "Unleaded":
          Stats.UnleadedDispensed += Stats.ToDispense;
          break;
        case "Diesel":
          Stats.DieselDispensed += Stats.ToDispense;
          break;
        case "LPG":
          Stats.LPGDispensed += Stats.ToDispense;
          break;

      }
    }

  }
}
