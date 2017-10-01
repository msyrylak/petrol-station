using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.InteropServices;

//myAssignment
//Author: Maja Syrylak
//SID: 1611379

namespace myAssignment
{
  class Program
  {
    public static Random random = new Random();

    // create a queue of vehicles
    public static List<Vehicle> vehicleLine = new List<Vehicle>(); //https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx

    //http://stackoverflow.com/questions/19882766/how-to-import-getasynckeystate-in-c
    [DllImport("user32.dll")] // import user32.dll library for GetAsyncKeyState function 
    public static extern bool GetAsyncKeyState(Keys vkey);

    static void Main(string[] args)
    {
      // create an array of pumps 
      Pump[,] pumpLine = new Pump[3, 3];


      Console.CursorVisible = false;

      // a for loop to create pumps
      for (int i = 0; i < pumpLine.GetLength(0); i++)
      {
        for (int j = 0; j < pumpLine.GetLength(1); j++)
        {
          pumpLine[i, j] = new Pump(i * pumpLine.GetLength(1) + j);
        }
      }

      bool quit = false;
      do
      {
        // check every vehicle if the time to be serviced ended and if it did remove it
        foreach (Vehicle v in vehicleLine.ToList())
        {
          if (v.leave == true)
          {
            vehicleLine.Remove(v);
            Stats.VehiclesGone++; // counter for all the vehicles that left without being serviced
          }
        }

        VehicleGenerator.GetVehicle();  // call a method creating new vehicles

        // iterate over every pump and call a PumpLine() method
        for (int i = pumpLine.GetLength(0) - 1; i >= 0; i--)
        {
          for (int j = pumpLine.GetLength(1) - 1; j >= 0; j--)
          {
            pumpLine[i, j].PumpManager();
          }
        }

        if (Utils.refresh == true)
        {
          // display pump lanes
          for (int i = 0; i < pumpLine.GetLength(1); i++)
          {
            Console.SetCursorPosition(0, i); //https://msdn.microsoft.com/en-us/library/system.console.setcursorposition%28v=vs.110%29.aspx
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, i);
            Console.WriteLine("------" + pumpLine[i, 0].GetState() + "------" + pumpLine[i, 1].GetState() + "------" + pumpLine[i, 2].GetState() + "------");
          }

          for (int i = 0; i < pumpLine.GetLength(1); i++)
          {
            Console.SetCursorPosition(0, 5 + i);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 5 + i);
            Pump.PumpState s = pumpLine[i, 0].GetState();
            if (s == Pump.PumpState.Busy)
            {
              Console.WriteLine("Lane {0} blocked!", i + 1);
            }
            else
            {
              Console.WriteLine("Lane {0} not blocked!", i + 1);
            }
          }

          Console.SetCursorPosition(0, 9);
          Console.Write(new string(' ', Console.WindowWidth));
          Console.SetCursorPosition(0, 9);
          Console.WriteLine();
          Stats.ShowStats();

          Utils.refresh = false;
        }

        // to exit the program press escape
        if (GetAsyncKeyState(Keys.Escape))
        {
          //exit program
          quit = true;
          //open the text file with the recorded fuelling transactions
          //http://stackoverflow.com/questions/4055266/open-a-file-with-notepad-in-c-sharp
          System.Diagnostics.Process.Start("notepad.exe", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\fuelling_transactions.txt");
        }

      } while (!quit);
    }
  }
}
