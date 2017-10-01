using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace myAssignment
{
  class VehicleGenerator
  {
    public static Random random = new Random();
    public static bool allowed = true;

    private static void Timer_Elapsed(object sender, ElapsedEventArgs e) //https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.110).aspx
    {
      allowed = true;
    }

    /// <summary>
    /// this method generates a new vehicle using a random number generator and switch statement
    /// then enqueues it into our created queue
    /// after that the counter records a number of all vehicles created,
    /// displays next vehicle in line and counters: number of vehicles created, total litres dispensed, 
    /// total number of money earned and commission
    /// it also uses a timer to manage time in which a new vehicle is created
    /// </summary>
    public static void GetVehicle()
    {

      if (allowed && (Program.vehicleLine.Count() <= 5))
      {
        int type = random.Next(0, 3);
        Vehicle v;
        switch (type)
        {
          case 0:
          default:
            v = new Car();
            break;

          case 1:
            v = new Van();
            break;

          case 2:
            v = new HGV();
            break;
        }
        Program.vehicleLine.Add(v);
        Stats.VehiclesCreated++;
        Utils.refresh = true;

        allowed = false;
        Timer timer = new Timer();
        timer.AutoReset = false;
        timer.Interval = random.Next(1500, 2200);
        timer.Enabled = true;
        timer.Elapsed += Timer_Elapsed;
      }
    }
  }
}
