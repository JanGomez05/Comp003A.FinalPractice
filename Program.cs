/*
 * Author: Jan Gomez
 * Purpose: Final Assignment
 * Course: Comp003A L01
 * 
 */
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;

namespace finalproject_from_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // theme would be for health patient.
            SectionSeparator("Welcome to Hanfords Clinic!" +
             " Here is a Registry for new Patients." +
             " Please Answer and Label the inquiery.");

            Console.WriteLine("Enter a first name");
            string firstName = Run(Console.ReadLine());

            Console.WriteLine("PLease enter yout Last Name");
            string lastName = Run(Console.ReadLine());

            Console.WriteLine($"\n So you are {firstName} {lastName}");

            bool isValid = false;
            int year = 0;
            do
            {
                Console.WriteLine("When were you born?");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Please enter an actual integer");
                    continue;
                }
                if (year <= 1900 || year >= 2010)
                {
                    Console.WriteLine("Invalid Input");
                }
                else
                {
                    Console.WriteLine(AgeCalculator(year));
                }

                } while (year <= 1900 || year >= 2010);
           

            

            Console.WriteLine("Pease insert your gender as M , F or O:");
            
             char gender = Convert.ToChar(Console.ReadLine().ToLowerInvariant());
            
                switch (gender)
                {
                    case 'm':
                        Console.WriteLine($"{firstName} you are Male");
                        break;
                    case 'f':
                        Console.WriteLine($"{firstName} you are Female");
                        break;
                    case 'o':
                        Console.WriteLine($"{firstName} you are Other");
                        break;
                    default:
                        Console.WriteLine($"{firstName}, please enter out of the choices selected");
                        break;
                }

            List<string> response = new List<string>();

            List<string> question = new List<string>();

            question.Add("Are you enjoying your visit?");

            question.Add("Are You currently feeling pain?");

            question.Add("In the past few months have you been out of the country?");

            question.Add("Have you been having fever like symptoms?");

            question.Add("Have you tested for covid-19 in the past 2-4 weeks?");

            question.Add("Are you physically active?");

            question.Add("Do you smoke?");

            question.Add("Do you drink alcohol?");

            question.Add("Have you been consuming drugs?");

            question.Add("Do you have any allergins?");


            foreach (string a in question)
            {

                Console.WriteLine(a);
                string answer = Console.ReadLine();
                response.Add(answer);

            }


        }// end of main code.

        /// <summary>
        /// Leaving title for the final
        /// </summary>
        /// <param name="section"></param>
        static void SectionSeparator(string section)
        {
            Console.WriteLine("".PadRight(130, '*') +
                $"\n\t\t{section} \n"
                + "".PadRight(130, '*'));
        }
        /// <summary>
        /// removing special characters from first name
        /// </summary>
        /// <param name="Name"></param>
        static string Run(string name)
        {
           
            // Make own character set
            Regex regex = new Regex("[@_!#$%^&*()<>?/|}{~:]");
            // Pass the string in regex.IsMatch
            // method
            if (!regex.IsMatch(name))
            {
                Console.WriteLine("That's a good name");
                return name;
            }
            else
            {
                Console.WriteLine("That is not a name");
                Console.WriteLine("Please try again. Enter a valid name");
                name = Run(Console.ReadLine());
                return name;
            }
        }
 
        /// <summary>
        /// grabbing patients Birth Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        static int AgeCalculator(int year)
        {  
           // Console.WriteLine($"Your age is: {AgeCalculator(year)}");
            return DateTime.Now.Year - year;
        }

    }
}
   