using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSelectionQueries
{
    class Program
    {
        static void Main(string[] args)
        {

             VehicleConfigurationDataContext VCdb = new VehicleConfigurationDataContext();

            if (!VCdb.DatabaseExists())
                throw new Exception();

            Console.WriteLine("Years:");

            //Get Years
            var syear = (from yr in VCdb.VehicleConfigurationViews
                         select yr.YearID).Distinct().OrderByDescending(yr => yr);

            foreach (var yr in syear)
            {
                Console.WriteLine(yr);
            }
            Console.WriteLine();

            Console.WriteLine("Makes for Selected Year:");

            //Get Makes for Selected Year
            var yrmake = (from mk in VCdb.VehicleConfigurationViews
                          where mk.YearID == 2015
                          select mk.MakeName).Distinct().OrderBy(mk => mk);

            foreach (var mk in yrmake)
            {
                Console.WriteLine(mk);
            }
            Console.WriteLine();

            Console.WriteLine("Models for Selected Year and Make:");

            //Get Models for Selected Year and Make
            var yrmakemod = (from mkmod in VCdb.VehicleConfigurationViews
                             where mkmod.YearID == 2015 && mkmod.MakeName == "Ford"
                             select mkmod.ModelName).Distinct().OrderBy(mkmod => mkmod);

            foreach (var mkmod in yrmakemod)
            {
                Console.WriteLine(mkmod);
            }
            Console.WriteLine();

            Console.WriteLine("Engines for Selected Year, Make, and Model:");

            //Get Engine for Selected Year, Make, and Model
            var yrmakemodeng = (from mkmoden in VCdb.VehicleConfigurationViews
                                where mkmoden.YearID == 2015 && mkmoden.MakeName == "Ford" && mkmoden.ModelName == "Fusion"
                                select mkmoden.Liter).Distinct();

            foreach (var mkmoden in yrmakemodeng)
            {
                Console.WriteLine(mkmoden);
            }
            Console.WriteLine();

            Console.WriteLine("Distinct Year, Make, Model, Engine and BaseVehicleID:");

            //Get BaseVehicleID for Selected Year, Make, Model and Engine 
            var bvid = (from bv in VCdb.VehicleConfigurationViews
                        where bv.YearID == 2015 && bv.MakeName == "Ford" && bv.ModelName == "Fusion" && bv.Liter == "2.0"
                        select new { bv.YearID, bv.MakeName, bv.ModelName, bv.Liter, bv.BaseVehicleID }).Distinct();

            foreach (var bv in bvid)
            {
                Console.WriteLine(bv.YearID.ToString() + bv.MakeName + bv.ModelName + bv.Liter + bv.BaseVehicleID);
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

