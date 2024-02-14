using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.MasterModules
{
    public class LocationsViewModel:locations
    {
        public List<CategoriesViewModel> Categories { get; set; }

    }

    public class CategoriesViewModel : categories
    {
        public List<Fees> Fees { get; set; }
    }
}
