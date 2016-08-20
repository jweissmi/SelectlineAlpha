using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    public partial class VehicleConfigurationView
    {

        public static IEnumerable<VehicleConfigurationView> SelectYear(int? selYear, VehicleConfigurationDataContext VCdb)
        {
            var sYear = (from yr in VCdb.VehicleConfigurationViews
                         where yr.YearID >= 1990
                         orderby yr.YearID descending
                         select yr).Distinct();

            return sYear;
        }


    }
}