using System.Transactions;
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
            getInfo();                       
        } 
        // end main

        // methods start
        /// <summary>
        /// Asks for user's Name
        /// </summary>
        static void getInfo()
        {
            PrintSeparator("Personal Information");
            // Get Name
            Console.Write("Enter First Name: "); // get first name
            string firstName = Console.ReadLine();
           
            while (string.IsNullOrEmpty(firstName) || isInt(firstName))
            {
                Console.WriteLine("\nInput cannot contain null/empty/numbers/special characters!");
                Console.WriteLine("Please Try Again..." + "\n".PadRight(60, '_'));

                Console.Write("\nEnter First Name: ");
                firstName = Console.ReadLine();
            }

            Console.Write("Enter Last Name: "); //get last name
            string lastName = Console.ReadLine();

            while (string.IsNullOrEmpty(lastName) || isInt(lastName))
            {
                Console.WriteLine("\nInput cannot contain null/empty/numbers/special characters!");
                Console.WriteLine("Please Try Again..." + "\n".PadRight(60, '_'));

                Console.Write("\nEnter Last Name: ");
                lastName = Console.ReadLine();
            }

            // Get Gender
            PrintSeparator("Gender");
            try
            {
                Console.Write("Enter your Gender | [M]-male | [F]-female | [O]-others |: ");
                char getGender = Convert.ToChar(Console.ReadLine());
                
                if (getGender == 'M' || getGender == 'm')
                {
                    Console.WriteLine("Male");
                }
                else if  (getGender == 'F' || getGender == 'f')
                {
                    Console.WriteLine("Female");
                }
                else if (getGender == 'O' || getGender == 'o')
                {
                    Console.WriteLine("Others");
                }
                else
                {
                    Console.WriteLine("\nTry Again" + "\nPress any key to continue...");
                    Console.Read();
                    Console.Clear();
                    getInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Get Age
            try
            {
                PrintSeparator("Age");

                Console.Write("Enter YEAR of Birth: ");
                int year = Convert.ToInt32(Console.ReadLine());

                AgeCalculator(year);
                if (AgeCalculator(year) >= 18 && AgeCalculator(year) <= 120) // check age
                {
                    Console.Write($"Are you {AgeCalculator(year)} years old? [y] [n]:");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        // convert name to UPPER CASE
                        string fName = firstName;
                        fName = fName.ToUpper();
                        string lName = lastName;
                        lName = lName.ToUpper();

                        Console.Clear();
                        PrintSeparator("Dating Form");
                        Console.WriteLine($"\nHello, {fName} {lName}!" + " \nPlease answer the following questions correctly and truthfully.\n"); // display name

                        /* Questions Section */
                        PrintSeparator("Describe your interest/yourself");
                        try
                        {
                            List<string> answers = new List<string>(); // |>--------------------------------------------------------------------- data collection

                            Console.Write("\n1. What do you think is your favorite color: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n2. What is your favorite movie/series of all time: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n3. What is your favorite food: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n4. What is your favorite hobby: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n5. What is your spirit animal: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n6. What is the name of your favorite artist/band you listen to: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n7. What's something you're really passionate about: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n8. If you could travel anywhere in the world or outside of it, where would you go: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n9. What do you think is your love language: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Write("\n10. Describe yourself in one word: \n\t- ");
                            answers.Add(Console.ReadLine());

                            Console.Clear(); // clear console

                            Console.WriteLine($"\nThis are the things that summarizes what kind of person you are {fName} {lName} [{AgeCalculator(year)}]\n" + "".PadRight(80, '_'));
                            TraverseListAnswers(answers);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }

                        Console.Write("\nThank you for answering!" + " Would you like to try again? [y] [n]: ");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            getInfo();
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.N)
                        {
                            Console.WriteLine("\nPress any key to close the program...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError Input!\n\nPlease try again...");
                        Console.ReadKey();
                        Console.Clear();
                        getInfo();
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
                    getInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + "\n\nTry Again...");
                Console.ReadLine();
                Console.Clear();
                getInfo();
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
        /// For Checking integer
        /// </summary>
        /// <param name="check">checks each char in string input if it has an integer value</param>
        /// <returns></returns>  
        static bool isInt(string check)
        {
            foreach(char c in check)
            {
                if (!char.IsLetter(c)) // https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter?view=net-7.0
                {
                    return true;
                }               
            }
            return false;
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

        /// <summary>
        /// Traverse Answers
        /// </summary>
        /// <param name="answers">Prints answers</param>
        static void TraverseListAnswers(List<string> answers)
        {
            foreach (string answer in answers)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine("".PadRight(80, '_'));
        }
    }
}