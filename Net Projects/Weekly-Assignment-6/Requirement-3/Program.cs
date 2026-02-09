using System;
using System.Text.RegularExpressions;

namespace Requirment_3
{
    class Program
    {
        // checks if registration number follows the right format or nah
        static bool ValidateRegistartionNo(string registrationNo)
        {
            try
            {
                // pattern says: 2 capital letters, space, 1-2 digits, maybe some letters, space, then 1-4 digits
                string pattern = @"^[A-Z]{2}\s\d{1,2}(\s[A-Z]{1,2})?\s\d{1,4}$";
                // match the input against pattern, gives true or false
                return Regex.IsMatch(registrationNo, pattern);
            }
            catch (Exception)
            {
                // something broke so just say its not valid
                return false;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // ask user to type their reg number
                Console.WriteLine("Enter the Registration number");
                string regNo = Console.ReadLine();

                // run the check method on what they typed
                if (ValidateRegistartionNo(regNo))
                {
                    // format matched so tell them its good
                    Console.WriteLine("Registration number is valid!");
                }
                else
                {
                    // didnt match so tell them nope
                    Console.WriteLine("Registration Number is InValid");
                }
            }
            catch (Exception)
            {
                // if anything crashes show this error message
                Console.WriteLine("Error occurred while validating registration number");
            }
        }
    }
} 