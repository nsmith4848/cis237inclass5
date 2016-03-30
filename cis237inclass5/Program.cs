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

            Console.ReadLine();

            foreach (Car car in carsNSmithEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }

            Console.WriteLine("");
            Console.WriteLine("Find a record by different properties");
            Console.ReadLine();

            //***********************************************************************
            //Find a specific one by any property
            //*************************************************************************

            //Call the Where method on the table Cars and pass in a lambda expression
            //For the criteria we are looking for.  There is nothing special about the word
            //car in the part that reads: car => car.id == "V0...".  It could be any characters we
            //want it to be.  It is just a variable name for the current car we are considering
            //in the expression.  This will automagically loop through all the Cars, and run the expression against each of them. 
            //When the result is finally true, it will return that car.
            Car carToFind = carsNSmithEntities.Cars.Where(car => car.id == "WM28504").First();

            //We can look for a specific model from the database.  With a where clause based on any 
            //criteria we want we can narrow it down.  Here we are doing it with the Car's model 
            //instead of its id.
            Car otherCarToFind = carsNSmithEntities.Cars.Where(car => car.model == "Challenger").First();
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);
            Console.WriteLine(otherCarToFind.id + " " + otherCarToFind.make + " " + otherCarToFind.model);

            Console.WriteLine("");
            Console.WriteLine("Find record based on primary key");

            Console.ReadLine();


            //**********************************************************
            //Find a car based on the primary key
            //************************************************************

            //Pull out a car from the table based on the primary id(shorthand for id only of the above method)
            Car foundCar = carsNSmithEntities.Cars.Find("WM28504");
            

            //Printed
            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model + " ");

            Console.WriteLine("");
            Console.WriteLine("Add a new record");

            Console.ReadLine();

            //**************************************************************
            //Add a new Car to the database
            //****************************************************************

            //Make and instance of a new car
            Car newCarToAdd = new Car();

            //Assign properties to the parts of the model            
            newCarToAdd.id = "NI88888";
            newCarToAdd.make = "Nssan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 550;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2016";
            newCarToAdd.type = "Car";

           
            try
            {
                carsNSmithEntities.Cars.Add(newCarToAdd);
                carsNSmithEntities.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("The ID entered is already in use.  Please select another");
                carsNSmithEntities.Cars.Remove(newCarToAdd);
            }
            Car anotherFoundCar = carsNSmithEntities.Cars.Find("NI88888");

            Console.WriteLine(anotherFoundCar.id + " " + anotherFoundCar.make + " " + anotherFoundCar.model);

            Console.WriteLine("");
            Console.WriteLine("Update the added record");

            Console.ReadLine();

            //************************************************************
            //Update
            //**************************************************************

            //Get a car out of the database that we would like to update           
                Car carToUpdate = carsNSmithEntities.Cars.Find("NI88888");                      
            //Update some of the properties of the car we found.  Don't need to update all of 
            //them if we don't want to.  I choose these 4.
            carToUpdate.make = "Nissan";
            carToUpdate.model = "GT-RRRRRRRRRR";
            carToUpdate.horsepower = 1250;
            carToUpdate.cylinders = 16;

            //Don't need to 'put it back in' since we only pulled out a reference
            carsNSmithEntities.SaveChanges();

            //re-search the car
            anotherFoundCar = carsNSmithEntities.Cars.Find("NI88888");
            //Print the changed record
            Console.WriteLine(anotherFoundCar.id + " " + anotherFoundCar.make + " " + anotherFoundCar.model);
            Console.WriteLine("");
            Console.WriteLine("Delete Added Item");

            Console.ReadLine();

            //********************************************************************
            //Delete
            //********************************************************************

            //Remove the Car from the Cars collection
            Car carToFindForDelete = carsNSmithEntities.Cars.Find("NI88888");

            carsNSmithEntities.Cars.Remove(carToFindForDelete);

            carsNSmithEntities.SaveChanges();

            Console.WriteLine("Item Deleted");

            try
            {
                carToFindForDelete = carsNSmithEntities.Cars.Find("NI88888");
                Console.WriteLine(carToFindForDelete.id + " " + carToFindForDelete.make + " " + carToFindForDelete.model);
            }

            catch
            {
                Console.WriteLine("The model you are looking for does not exist");
            }
        }      
    }
}