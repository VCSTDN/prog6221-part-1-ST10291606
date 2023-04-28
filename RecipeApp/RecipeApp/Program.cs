using Microsoft.VisualBasic.FileIO;
using RecipeApp;
using System;
using System.Transactions;
using System.Text.RegularExpressions;

public class Program
{
    private static double[] originalQuantities; // Empty array to store the original quantities
    

    public static void Main(string[] args)
    {

        Console.BackgroundColor = ConsoleColor.DarkBlue; // Changes the colour of the text background in the application (w3schools.com)
        Console.ForegroundColor = ConsoleColor.Black; // Changes the colour of the text presented to the user (w3schools.com)

        repeat: // label needed for the goto statement to operate correctly. The application restarts from this point when the goto statement is read. (programiz.com)

        // The user should be able to store the details for a single recipe.

        Console.WriteLine("*************************************");
        Console.WriteLine("Welcome to my recipe application");
        Console.WriteLine("*************************************");

        int numofIngredients; // Number of ingredients.

        Ingredient ingredient; // Create an object of the ingredient class.

        Ingredient[] ingredients; // This is the array for all the ingredients.

        int numofSteps; // Number of steps 

        Step step; // Create an obkect of the step class 

        Step[] steps; // This is the array for all steps

        Console.WriteLine("\nEnter the number of Ingredients:");
        numofIngredients = Convert.ToInt32(Console.ReadLine());

        ingredients = new Ingredient[numofIngredients]; // Initializing the declared array of ingredients with a size according to the number of ingredients the user enters

        int count = 0; // Counts the number of times the loop has been run through 

        while (count < numofIngredients) // While loop to recieve user input for name, quantity and unit of measurement for each ingredient
        {
            ingredient = new Ingredient(); // Each loop will create a new object

            Console.WriteLine("\nFor Ingredient " + (count + 1) + ": \n"); // User enters deatils for nect ingredient

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


        Console.WriteLine("\nEnter the number of steps: ");
        numofSteps = Convert.ToInt32(Console.ReadLine());

        steps = new Step[numofSteps]; // Initializing the declared array of steps with a size according to the number of steps to the recipe

        int count2 = 0; // Counts the number of times the loop has been run through 

        while (count2 < numofSteps) // While loop to recieve users description for each step
        {
            step = new Step(); // Each loop creates a new object 

            Console.WriteLine("\nFor step " + (count2 + 1) + ": \n");

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


        while (true) // While loop to display options to the user 
        {
            Console.WriteLine("\nChoose an option number:");
            Console.WriteLine("(1) = Display recipe");
            Console.WriteLine("(2) = Scale recipe");
            Console.WriteLine("(3) = Reset quantities");
            Console.WriteLine("(4) = Clear recipe");
            Console.WriteLine("(5) = Exit the application");
            Console.WriteLine("(6) = Restart the application with a new recipe");
            

            string option = Console.ReadLine(); // Recieves user input 


            // If stattmets to determine the users decision and then call the correct method after input is taken
           // Menu control flow

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
                Console.WriteLine("Are you sure you want to clear your recipe? ");
                Console.WriteLine("Select Y for yes or N for no: ");

                string clearDecision = Console.ReadLine();
                if (clearDecision == "Y") 
                {
                    ClearRecipe();
                    Console.WriteLine("\nThe recipe has been cleared.");

                    DisplayRecipe();

                }

                else if (clearDecision == "N") 
                { 
                    DisplayRecipe();
                }

            }

            else if (option == "5")
            {
                break; // Ends the application
            }

            else if (option == "6")
            {
                goto repeat; // goto statement which will return the application to where the label for the goto statement is placed. (programiz.com)
            }

            else
            {
                Console.WriteLine("You have entered an invlaid number. Please try again. ");
            }


            void DisplayRecipe() // Method to display the recipe
            {
                Console.WriteLine();

                //Changes the text colours once more (w3schools.com)
                Console.BackgroundColor = ConsoleColor.Yellow; 
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Here are the ingredients needed for your recipe: \n");

                foreach (var ingred in ingredients) // for each loop to display each attribute of the ingredients
                {
                    Console.WriteLine("Name: " + ingred.name + "\n" + "Quantity: " + ingred.quantity + "\n" + "Unit of measurement: " + ingred.unitofMeasurement + "\n");
                }

                Console.WriteLine();
                Console.WriteLine("Here is a description of the steps in the recipe: \n");

                int stepNumber = 1; // added a counter to display the step number in the following foreach loop

                foreach (var stepa in steps) // for each loop to display all the steps stores in steps 
                {
                    Console.WriteLine("Step " + stepNumber + " Description: " + stepa.description + "\n");
                    stepNumber++;
                }

            }

            void ScaleRecipe(double factor) // Method to scale the ingredient quantities by the given factor
            {
                for (int i = 0; i < ingredients.Length; i++)
                {
                    ingredients[i].quantity *= factor;

                }
            }

            void ResetQuantities() // Reset the ingredient quantities to their original values
            {

                for (int i = 0; i < ingredients.Length; i++)
                {
                    ingredients[i].quantity = originalQuantities[i];
                }
            }

            void ClearRecipe() // Clear the ingredients and steps arrays
            {

                ingredients = new Ingredient[0];
                steps = new Step[0];
            }

        }
        
    }

}
