// ==============================
// Concert Filter & Export App
// This app filters a list of bands by ticket price
// and saves the filtered results to a file.
// (Beginner version: no use of List)
// ==============================

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Band names
        string[] bands = { "The Beatles", "Nirvana", "Coldplay", "Metallica", "Adele" };

        // Ticket prices for each band (same order as bands array)
        decimal[] ticketPrices = { 150.00m, 90.50m, 120.00m, 200.00m, 75.00m };

        // Variable to control looping
        bool keepRunning = true;

        // Run the program in a loop so users can filter again
        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Concert Filter & Export App");
            Console.WriteLine("----------------------------");

            Console.Write("Enter maximum ticket price: $");

            // Try to read and convert the user's input to a decimal number
            if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.WriteLine("Press Enter to try again...");
                Console.ReadLine();
                continue; // Go back to the top of the loop
            }

            // Create an array to store up to 5 matching results (same size as bands)
            string[] filteredResults = new string[bands.Length];
            int matchCount = 0; // Counter for how many matches we find

            // Go through each band and price
            for (int i = 0; i < bands.Length; i++)
            {
                // Check if the ticket price is less than or equal to the user's max
                if (ticketPrices[i] <= maxPrice)
                {
                    // Format the result as a string and store it in the array
                    filteredResults[matchCount] = bands[i] + " - $" + ticketPrices[i].ToString("0.00");
                    matchCount++; // Keep track of how many we’ve stored
                }
            }

            Console.WriteLine("\nFiltered Results:");

            // If no matches were found, show a message
            if (matchCount == 0)
            {
                Console.WriteLine("No concerts found under that price.");
            }
            else
            {
                // Create an array to write to the file
                string[] linesToWrite = new string[matchCount];

                // Print the matching results to the screen
                for (int i = 0; i < matchCount; i++)
                {
                    Console.WriteLine(filteredResults[i]);
                    linesToWrite[i] = filteredResults[i]; // Copy to file output array
                }

                // Save the results to a file
                File.WriteAllLines("filtered_results.txt", linesToWrite);
                Console.WriteLine("\nResults saved to filtered_results.txt");
            }

            // Ask if the user wants to filter again
            Console.Write("\nWould you like to filter again? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            keepRunning = (choice == "y");
        }

        Console.WriteLine("\nThanks for using the Concert Filter App!");
    }
}
