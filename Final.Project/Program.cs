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
        /*========= end main =========*/

        /*======= methods start ======*/
        /// <summary>
        /// Asks for user's Name
        /// </summary>
        static void GetInfo()
        {
            PrintSeparator("Personal Information");
            // Get Name
            Console.Write("Enter First Name: "); // get first name
            string firstName = Console.ReadLine();
            InputName(firstName, "First");

            Console.Write("Enter Last Name: "); //get last name
            string lastName = Console.ReadLine();
            InputName(lastName, "Last");

            // Get Gender
            GetGender();

            // convert name to UPPER CASE
            string fName = firstName;
            fName = fName.ToUpper();
            string lName = lastName;
            lName = lName.ToUpper();

            Console.Clear();
            PrintSeparator("Dating Form");
            Console.WriteLine(
                $"\nHello, {fName} {lName}!"
                    + " \nPlease answer the following questions correctly and truthfully.\n"
            ); // display name

            PrintSeparator("Questions");
            Questions();
            Console.WriteLine("\n".PadRight(79, '*') + $"\nHello, {fName} {lName}! This are the things that summarizes what kind of person you are." + "\n".PadRight(79, '*'));
            // console.writeline($"{GetAge(AgeCalculator(year))} {GenderValue(GetGender)}") is not working

            // TODO: summary is missing the age [n/a]
            // TODO: summary is missing the full gender description [n/a]

            Console.Write("\nThank you for answering! Would you like to try again? Press [y] if yes or any key if not: ");

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
        // TODO: by convention, the underscore prefix for variable names are for private variables. change the _name if that is not the intention [DONE]
        static void InputName(string name, string names)
        {
            while (string.IsNullOrEmpty(name) || IsInt(name))
            {
                Console.WriteLine("\nInput cannot contain null/empty/numbers/special characters!");
                Console.WriteLine("Please Try Again..." + "\n".PadRight(60, '_'));

                Console.Write($"\nEnter {names} Name: ");
                name = Console.ReadLine();
            }
        }

        /// <summary>
        /// For Checking integer
        /// </summary>
        /// <param name="check">checks each char in string input if it has an integer value</param>
        /// <returns>if string character contains integers value is true if not false</returns>
        // TODO: fix this xml comment |>-------------------------------------------------------------------------------------------------------------[DONE]
        static bool IsInt(string check)
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
                string getGender = Console.ReadLine();
                getGender = getGender.ToLower();

                // TODO: normalize the data by reassigning the getGender value to either a lower case or upper case, so it's agnostic of letter case [DONE]
                // TODO: after getGender is reassigned, one of the condition for each clause becomes redundant |>------------------------------------[DONE]
                while ((getGender != "m" && getGender != "f" && getGender != "o") || string.IsNullOrEmpty(getGender))
                {
                    Console.Write(
                        "\n".PadRight(50, '_') + "\nIvalid input!\n" + "\nTry Again"
                            + "\nPlease Enter provided characters [M/F/O]: "
                    );
                    getGender = Console.ReadLine();
                }
                string gender = GenderValue(getGender);
                gender = gender.ToUpper();
                Console.WriteLine("".PadRight(22, '_') + $"\nYou Identify as {gender}");
                Console.ReadKey();
                Console.Clear();
                GetAge();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nError: Invalid Input\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                GetGender();
            }
        }

        /// <summary>
        /// Get Gender Input
        /// </summary>
        /// <param name="getgender">input gender value and converts it to lowercase</param>
        /// <returns>gender value based on case</returns>
        static string GenderValue(string getGender)
        {
            switch (getGender.ToLower())
            {
                case "m":
                    return "Male";
                case "f":
                    return "Female";
                case "o":
                    return "Others";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Get Age and identify User Rating
        /// </summary>
        static void GetAge()
        {
            try
            {
                PrintSeparator("Age");
                Console.Write("Enter YEAR of Birth: ");
                // TODO: put this line in a try-catch to handle exceptions for non-numeric values |>-----------------------------------------------[DONE]
                int year = Convert.ToInt32(Console.ReadLine());

                AgeCalculator(year);
                if (AgeCalculator(year) >= 18 && AgeCalculator(year) <= 120) // check age
                {
                    Console.Write(
                        $"Is this your age [{AgeCalculator(year)}] years old? Press [y] if yes or any key if not: "
                    );
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        /* Questions Section */
                        PrintSeparator("Describe your interest/yourself");
                    }
                    else
                    {
                        Console.WriteLine("\n\nPlease try again...");
                        Console.ReadKey();
                        Console.Clear();
                        GetAge();
                    }
                }
                else if (AgeCalculator(year) < 18 && AgeCalculator(year) >= 0)
                {
                    Console.WriteLine(
                        $"\nUsers aged {AgeCalculator(year)} years old are not permitted"
                    );
                    Console.WriteLine(
                        "\nAge rating is for 18+ age and above!" + "\n\nClosing Program..."
                    );
                    Console.ReadKey();
                    Console.Clear();
                    Environment.Exit(1); // exit console
                }
                else
                {
                    Console.WriteLine("\nInvalid Input! Please try again...");
                    Console.ReadKey();
                    Console.Clear();
                    GetAge();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + "\n\nTry Again...");
                Console.ReadLine();
                Console.Clear();
                GetAge();
            }
        }

        /// <summary>
        /// Question Lists
        /// </summary>
        static void Questions()
        {
            // TODO: validate user responses to make sure it is not null or empty. consider creating a method for this purpose. |>-----------------[DONE]
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

                List<string> answers = new List<string>(); // Data Collection

                // TODO: this section is a repeating task, put it in a looping statement |>--------------------------------------------------------[DONE]
                foreach (string question in questions)
                {
                    Console.Write($"{question}\n\t- ");
                    string answer = Console.ReadLine();

                    while (string.IsNullOrEmpty(answer))
                    {
                        Console.WriteLine($"\n".PadRight(50, '_') + "\nTry to answer the question. Don't leave it blank!\n");
                        Console.Write($"{question}\n\t- {answer}");
                        answer = Console.ReadLine();
                    }
                    answers.Add(answer);
                }

                Console.Clear(); // clear console

                Console.WriteLine($"\n".PadRight(50, '*') + "\n\tSummary" + "\n".PadRight(50, '*'));
                int i = 0;
                do
                {
                    Console.WriteLine($"{questions[i]} {answers[i]}\n ");
                    i++;
                } while (i < 10);
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
