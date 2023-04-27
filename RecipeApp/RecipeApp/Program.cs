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

        Console.WriteLine("Welcome to my recipe application");
        Console.WriteLine("*************************************");

        int numofIngredients;

        Ingredient ingredient;

        Ingredient[] ingredients;

        int numofSteps;

        Step step;

        Step[] steps;

        Console.WriteLine("Enter the number of Ingredients");
        numofIngredients = Convert.ToInt32(Console.ReadLine());

        ingredients = new Ingredient[numofIngredients];

        int count = 0;

        while (count < numofIngredients)
        {
            ingredient = new Ingredient();

            Console.WriteLine("For Ingredient " + (count + 1) + ": ");

            Console.WriteLine("Enter the name: ");
            ingredient.name = Console.ReadLine();

            Console.WriteLine("Enter the quantity: ");
            ingredient.quantity = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the unit of measurement: ");
            ingredient.unitofMeasurement = Console.ReadLine();

            for (int i = count; i < numofIngredients; i++)
            {
                ingredients[i] = ingredient;
            }

            count++;

        }





        Console.WriteLine("Enter the number of steps: ");
        numofSteps = Convert.ToInt32(Console.ReadLine());

        steps = new Step[numofSteps];

        int count2 = 0;

        while (count2 < numofSteps)
        {
            step = new Step();

            Console.WriteLine("For step " + (count2 + 1) + ": ");

            Console.WriteLine("Enter the description for this step: ");
            step.description = Console.ReadLine();

            for (int j = count2; j < numofSteps; j++)
            {
                steps[j] = step;
            }

            count2++;

        }

        void SaveOriginalQuantities()
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
