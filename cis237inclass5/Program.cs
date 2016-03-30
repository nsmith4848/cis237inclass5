using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Use Port 443

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            CarsNSmithEntities carsNSmithEntities = new CarsNSmithEntities();

            Console.WriteLine("Print the list");

            foreach(Car car in carsNSmithEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }
        }
    }
}
