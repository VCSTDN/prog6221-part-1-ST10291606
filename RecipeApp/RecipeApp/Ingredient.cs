using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    // This class contains properties needed to store the names, quantities and units of measurement
    internal class Ingredient
    {
        public string name { get; set; }
        public double quantity { get; set; }
        public string unitofMeasurement { get; set; }
    }
}
