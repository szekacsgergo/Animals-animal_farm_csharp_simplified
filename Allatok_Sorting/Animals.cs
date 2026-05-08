using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allatok_Sorting
{
    //1. Create a class to store and reach the data from the file.
    public class Animals
    {
        public string animal_name { get; set; }
        public double animal_weight { get; set; }
        public int animal_avg_age { get; set; }
        public string animal_type { get; set; }
        public Animals(string line)
        {
            string[]count=line.Split(';');
            animal_name = count[0];
            animal_weight=Convert.ToDouble(count[1]);
            animal_avg_age = Convert.ToInt32(count[2]);
            animal_type = count[3];
        }
    }
}
