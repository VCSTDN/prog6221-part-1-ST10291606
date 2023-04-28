using Microsoft.VisualBasic.FileIO;
using RecipeApp;
using System;
using System.Transactions;

public class Program
{
    private static double[] originalQuantities;

    public static void Main(string[] args)
    {
        Recipe recipe = new Recipe();

        // The user should be able to store the details for a single recipe. 
        Console.WriteLine("Welcome to my recipe application");
        Console.WriteLine("*************************************");

        int numofIngredients; // Number of ingredients.

        Ingredient ingredient; // Create an object of the ingredient class.

        Ingredient[] ingredients; // This is the array for all the ingredients.

        int numofSteps; // Number of steps 

        Step step; // Create an obkect of the step class 

        Step[] steps; // This is the array for all steps

        Console.WriteLine("Enter the number of Ingredients");
        numofIngredients = Convert.ToInt32(Console.ReadLine());

        ingredients = new Ingredient[numofIngredients]; // Initializing the declared array of ingredients with a size according to the number of ingredients the user enters

        int count = 0; // Counts the number of times the loop has been run through 

        while (count < numofIngredients) // While loop to recieve user input for name, quantity and unit of measurement for each ingredient
        {
            ingredient = new Ingredient(); // Each loop will create a new object

            Console.WriteLine("For Ingredient " + (count + 1) + ": "); // User enters deatils for nect ingredient

            Console.WriteLine("Enter the name: ");
            ingredient.name = Console.ReadLine();

            Console.WriteLine("Enter the quantity: ");
            ingredient.quantity = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the unit of measurement: ");
            ingredient.unitofMeasurement = Console.ReadLine();

            for (int i = count; i < numofIngredients; i++) // Stores the user input into the array
            {
                ingredients[i] = ingredient;
            }

            count++; // Incerases the value of the count by 1

            // The loop will now return to its start and repeat itself for the next ingredient 
        }


        Console.WriteLine("Enter the number of steps: ");
        numofSteps = Convert.ToInt32(Console.ReadLine());

        steps = new Step[numofSteps]; // Initializing the declared array of steps with a size according to the number of steps to the recipe

        int count2 = 0; // Counts the number of times the loop has been run through 

        while (count2 < numofSteps) // While loop to recieve users description for each step
        {
            step = new Step(); // Each loop creates a new object 

            Console.WriteLine("For step " + (count2 + 1) + ": ");

            Console.WriteLine("Enter the description for this step: ");
            step.description = Console.ReadLine();

            for (int j = count2; j < numofSteps; j++) // Stores the user input into the array
            {
                steps[j] = step;
            }

            count2++; 

        }

        void SaveOriginalQuantities() // method created to store all the original quantities 
        {
            originalQuantities = new double[ingredients.Length];
            for (int i = 0; i < ingredients.Length; i++)
            {
                originalQuantities[i] = ingredients[i].quantity;
            }
        }

        SaveOriginalQuantities();


        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Display recipe");
            Console.WriteLine("2. Scale recipe");
            Console.WriteLine("3. Reset quantities");
            Console.WriteLine("4. Clear recipe");
            Console.WriteLine("5. Exit");

            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine();
                DisplayRecipe();

            }

            else if (option == "2")
            {
                Console.WriteLine("\nEnter the scaling factor (0.5, 2, or 3):");
                double factor = Convert.ToDouble(Console.ReadLine());

                ScaleRecipe(factor);

                Console.WriteLine("\nRecipe scaled successfully.");
                DisplayRecipe();
            }

            else if (option == "3")
            {
                ResetQuantities();
                Console.WriteLine("\nThe quantities have been reset. ");

                DisplayRecipe();

            }

            else if (option == "4")
            {
                ClearRecipe();
                Console.WriteLine("\nThe recipe has been cleared.");

                DisplayRecipe();

            }

            else if (option == "5")
            {
                break;

            }

            else
            {
                Console.WriteLine("You have entered an invlaid number. Please try again. ");
            }





            void DisplayRecipe()
            {
                Console.WriteLine();
                Console.WriteLine("Here are the ingredients stored in the application: ");

                foreach (var ingred in ingredients)
                {
                    Console.WriteLine("Name: " + ingred.name + "\n" + "Quantity: " + ingred.quantity + "\n" + "Unit of measurement: " + ingred.unitofMeasurement);
                }

                Console.WriteLine();
                Console.WriteLine("Here is a description of the steps in the recipe: ");

                foreach (var stepa in steps)
                {
                    Console.WriteLine("Description: " + stepa.description);
                }

            }

            void ScaleRecipe(double factor)
            {
                for (int i = 0; i < ingredients.Length; i++)
                {
                    ingredients[i].quantity *= factor;

                }
            }

            void ResetQuantities()
            {

                for (int i = 0; i < ingredients.Length; i++)
                {
                    ingredients[i].quantity = originalQuantities[i];
                }
            }

            void ClearRecipe()
            {

                ingredients = new Ingredient[0];
                steps = new Step[0];
            }

        }




    }

}
