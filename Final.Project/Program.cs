using System.Diagnostics.Metrics;
using System.Transactions;
using System.Xml.Linq;
/*
 * Author: Ron Jeremy Reyes
 * Course: COMP-003A
 * Purpose: Final Project
 * 
 */
namespace Final.Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetInfo();
        }
        // end main

        // methods start
        /// <summary>
        /// Asks for user's Name
        /// </summary>
        static void GetInfo() // TODO: by convention, methods should be in PascalCase |>-----------------------------------------------------------[DONE]
        {
            PrintSeparator("Personal Information");
            // Get Name
            Console.Write("Enter First Name: "); // get first name
            string firstName = Console.ReadLine();
            // TODO: consider creating a separate method for validating the firstName and lastName inputs as they perform the same logic |>--------[DONE]
            InputName(firstName, "First");

            Console.Write("Enter Last Name: "); //get last name
            string lastName = Console.ReadLine();
            // TODO: consider creating a separate method for validating the firstName and lastName inputs as they perform the same logic |>--------[DONE]
            InputName(lastName, "Last");

            // Get Gender
            // TODO: consider creating a separate method for this section. |>----------------------------------------------------------------------[DONE]
            GetGender();

            // Get Age
            // TODO: create a separate method for this Age section
            GetAge();

            // convert name to UPPER CASE
            string fName = firstName;
            fName = fName.ToUpper();
            string lName = lastName;
            lName = lName.ToUpper();

            Console.Clear();
            PrintSeparator("Dating Form");
            Console.WriteLine($"\nHello, {fName} {lName}!" + " \nPlease answer the following questions correctly and truthfully.\n"); // display name

            PrintSeparator("Questions");
            Questions();
            Console.WriteLine($"\nHello, {fName} {lName}!" + " This are the things that summarizes what kind of person you are.");

            Console.Write("\nThank you for answering!" + " Would you like to try again? Press [y] if yes or any key if not: ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Clear();
                GetInfo();
            }
            else
            {
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Section Separator
        /// </summary>
        /// <param name="header">Prints Section Header Name</param>
        static void PrintSeparator(string header)
        {
            Console.WriteLine("".PadRight(50, '*') + $"\n\t{header} - Section\n" + "".PadRight(50, '*'));
        }

        /// <summary>
        /// Name Input
        /// </summary>
        /// <param name="name">user input name</param>
        /// <param name="_name">name parameter </param>
        static void InputName(string name, string _name)
        {
            while (string.IsNullOrEmpty(name) || IsInt(name))
            {
                Console.WriteLine("\nInput cannot contain null/empty/numbers/special characters!");
                Console.WriteLine("Please Try Again..." + "\n".PadRight(60, '_'));

                Console.Write($"\nEnter {_name} Name: ");
                name = Console.ReadLine();
            }
        }

        /// <summary>
        /// For Checking integer
        /// </summary>
        /// <param name="check">checks each char in string input if it has an integer value</param>
        /// <returns></returns>  
        static bool IsInt(string check) // TODO: by convention, methods should be in PascalCase
        {
            foreach (char c in check)
            {
                if (!char.IsLetter(c)) // https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter?view=net-7.0
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Identifies user gender
        /// </summary>
        static void GetGender()
        {
            PrintSeparator("Gender");
            try
            {
                Console.Write("Enter your Gender | [M]-male | [F]-female | [O]-others |: ");
                char getGender = Convert.ToChar(Console.ReadLine());

                if (getGender == 'M' || getGender == 'm')
                {
                    Console.WriteLine("Male");
                }
                else if (getGender == 'F' || getGender == 'f')
                {
                    Console.WriteLine("Female");
                }
                else if (getGender == 'O' || getGender == 'o')
                {
                    Console.WriteLine("Others");
                }
                else
                {
                    Console.WriteLine("\nIvalid input!\nPlease Enter provided characters: [M/F/O]\n\nTry Again" + "\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    GetGender(); // TODO: an invalid input restarts this ENTIRE method. consider creating a separate method for the gender section, so it only repeats this section (not the entire getInfo()) [DONE]. you may also change your validation technique [PENDING]
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nError: Invalid Input\n" + ex.Message); // TODO: this Gender section should repeat if a string longer than 1 character is entered [DONE]
                Console.ReadKey();
                Console.Clear();
                GetGender();
            }
        }

        static void GetAge()
        {
            try
            {
                PrintSeparator("Age");
                Console.Write("Enter YEAR of Birth: ");
                int year = Convert.ToInt32(Console.ReadLine());

                AgeCalculator(year);
                if (AgeCalculator(year) >= 18 && AgeCalculator(year) <= 120) // check age
                {
                    Console.Write($"Is this your age [{AgeCalculator(year)}] years old? Press [y] if yes or any key if not: ");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        /* Questions Section */
                        PrintSeparator("Describe your interest/yourself");
                    }
                    else
                    {
                        Console.WriteLine("\n\nPlease try again..."); // TODO: be more descriptive as to why there is an error |>------------------[REVISED]
                        Console.ReadKey();
                        Console.Clear();
                        GetAge(); // TODO: again, the entire form resets, instead of repeating just the this (Age) section. |>---------------------[DONE]
                    }
                }
                else if (AgeCalculator(year) < 18 && AgeCalculator(year) >= 0)
                {
                    Console.WriteLine($"\nUsers aged {AgeCalculator(year)} years old are not permitted");
                    Console.WriteLine("\nAge rating is for 18+ age and above!" + "\n\nClosing Program...");
                    Console.ReadKey();
                    Console.Clear();
                    Environment.Exit(1); // exit console
                }
                else
                {
                    Console.WriteLine("\nInvalid Input! Please try again...");
                    Console.ReadKey();
                    Console.Clear();
                    GetAge(); // TODO: again, the entire form resets, instead of repeating just the this (Age) section. |>---------------------[DONE]
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + "\n\nTry Again...");
                Console.ReadLine();
                Console.Clear();
                GetAge(); // TODO: again, the entire form resets, instead of repeating just the this (Age) section.
            }
        }

        /// <summary>
        /// Question Lists
        /// </summary>
        static void Questions()
        {
            // TODO: put your questions in a data structure as well |>-----------------------------------------------------------------------------[DONE]
            // TODO: validate user responses to make sure it is not null or empty. consider creating a method for this purpose. |>-----------------[PENDING]
            try
            {
                List<string> questions = new List<string>();
                questions.Add("1. What do you think is your favorite color: ");
                questions.Add("2.What is your favorite movie / series of all time: ");
                questions.Add("3. What is your favorite food: ");
                questions.Add("4. What is your favorite hobby: ");
                questions.Add("5. What is your spirit animal: ");
                questions.Add("6. What is the name of your favorite artist/band you listen to: ");
                questions.Add("7. What's something you're really passionate about: ");
                questions.Add("8. If you could travel anywhere in the world or outside of it, where would you go: ");
                questions.Add("9. What do you think is your love language: ");
                questions.Add("10. Describe yourself in one word: ");

                List<string> answers = new List<string>(); // |>--------------------------------------------------------------------- data collection

                Console.Write($"{questions[0]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[1]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[2]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[3]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[4]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[5]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[6]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[7]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[8]}\n\t- ");
                answers.Add(Console.ReadLine());
                Console.Write($"{questions[9]}\n\t- ");
                answers.Add(Console.ReadLine());

                Console.Clear(); // clear console                

                Console.WriteLine($"".PadRight(50, '*') + "\tSummary" + "".PadRight(50, '*'));
                int i = 0;
                do
                {
                    Console.WriteLine($"{questions[i]} {answers[i]} ");
                    i++;
                } while (i < 10);

                // TODO: this section should display the Question followed by the Response. (e.g., Question 1... Response 1... Question 2... Response 2...) [DONE]
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Method for calculating age
        /// </summary>
        /// <param name="year">Calculates age based on year input</param>
        /// <returns>Age</returns>
        static int AgeCalculator(int year)
        {
            return (DateTime.Now.Year - year);
        }
    }
}