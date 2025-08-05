// ==============================
// Concert Filter & Export App
// This app filters a list of bands by ticket price
// and saves the filtered results to a file.
// ==============================
class Program
{
    static void Main(string[] args)
    {
        // Create a string array of band names
        string[] bands = { "The Beatles", "Nirvana", "Coldplay", "Metallica", "Adele" };

        // Create a decimal array with the corresponding ticket prices
        decimal[] ticketPrices = { 150.00m, 90.50m, 120.00m, 200.00m, 75.00m };

        // This controls the loop to allow multiple filters
        bool keepRunning = true;

        // Keep looping while the user wants to filter again
        while (keepRunning)
        {
            // Clear the screen for a clean user interface
            Console.Clear();
            Console.WriteLine("Concert Filter & Export App");
            Console.WriteLine("----------------------------");

            // Ask the user to enter a maximum ticket price
            Console.Write("Enter maximum ticket price: $");

            // Try to parse the user input as a decimal (e.g., 100.00)
            if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
            {
                // If the user input is not a valid number, show an error and retry
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.WriteLine("Press Enter to try again...");
                Console.ReadLine();
                continue; // Skip to the next loop iteration
            }

            // Create a list to store matching results
            List<string> results = new List<string>();

            // Loop through each band and their ticket price
            for (int i = 0; i < bands.Length; i++)
            {
                // This is the FILTER:
                // If the current band's ticket price is less than or equal to maxPrice
                if (ticketPrices[i] <= maxPrice)
                {
                    // Format and add the result to the results list
                    results.Add($"{bands[i]} - ${ticketPrices[i]:0.00}");
                }
            }

            // Display the filtered results
            Console.WriteLine("\nFiltered Results:");

            // Check if any results were found
            if (results.Count == 0)
            {
                // BONUS: Show a message if no results match the filter
                Console.WriteLine("No concerts found under that price.");
            }
            else
            {
                // Loop through and print each matching result
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }

                // Save the results to a file called "filtered_results.txt"
                File.WriteAllLines("filtered_results.txt", results);
                Console.WriteLine("\nResults saved to filtered_results.txt");
            }

            // Ask the user if they want to filter again
            Console.Write("\nWould you like to filter again? (y/n): ");
            string choice = Console.ReadLine().ToLower();

            // Set keepRunning to true if user typed "y", otherwise false
            keepRunning = (choice == "y");
        }

        // Final message before the app closes
        Console.WriteLine("\nThanks for using the Concert Filter App!");
    }
}
