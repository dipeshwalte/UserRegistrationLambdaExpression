using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace UserRegistrationLambdaExpression
{
        
        public class UserValidation
        {
            static void ValidatePatterns(string pattern, string[] inputs)
            {
                Console.WriteLine("------------------------------------------");
                Regex re = new Regex(pattern);
                foreach (string input in inputs)
                {
                    if (re.IsMatch(input))
                        Console.WriteLine($"{input} is Valid");
                    else
                        Console.WriteLine($"{input} is inValid");
                }
                Console.WriteLine("-----------------------------------------");
            }
            public bool ValidatePattern(string pattern, string input)
            {
                Regex re = new Regex(pattern);
                return re.IsMatch(input);
            }
            public static void ValidatePatternUsingLambda(string pattern, string[] inputs,string entity)
            {
                Regex match = new Regex(pattern);
                List<string> newList = new List<string>(inputs);
                List<string> validPatternList = newList.Select(str => match.Match(str).Value).ToList();
                validPatternList.Remove("");
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Passed Patterns for {entity} : ");
                foreach (var item in inputs)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine($"Valid Patterns for {entity} :");
                foreach (var item in validPatternList)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------");
            }

            static void Main(string[] args)
            {
                string firstNamePattern = "[A-Z][a-z]{2,}";
                string[] firstNameInputs = { "dipesh1", "Dipesh", "Di", "Dinesh", "Dha", "Dhanesh" };
                ValidatePatternUsingLambda(firstNamePattern, firstNameInputs, "First Name");

                string lastNamePattern = "[A-Z][a-z]{2,}";
                string[] lastNameInputs = { "walte", "Walte", "Wa", "Zokhowizh", "Wha" };
                ValidatePatternUsingLambda(lastNamePattern, lastNameInputs,"Last Name");

                string emailPattern = @"^[0-9a-zA-Z]+[\-\.+]?[A-Za-z0-9]*@[0-9A-Za-z]+\.[a-zA-Z]{2,4}\.?([a-zA-Z]{2,4})?$";
                string[] emailInputs = { "abc.xyz@bl.co.in", "abc@bl.co", "abc@bl", "abc@bc.com" };
                ValidatePatternUsingLambda(emailPattern, emailInputs,"Email Pattern");

                string phonePattern = @"^[0-9]{2}\s[0-9]{10}$";
                string[] phoneInputs = { "91 9422421317", "54 942242131", "9422421315", "9 9422421317" };
                ValidatePatternUsingLambda(phonePattern, phoneInputs,"Phone");

                string passwordPattern = @"(?=.*[A-Z])(?=.*[0-9])(?=[^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*[.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\][^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*$)[0-9A-Za-z!@#\$%\^&\*\(\)\-\+]{8,}";
                string[] passwordInputs = { "1A!2345678", "1!!Asrwerds", "fdsaf", "fetsetv!", "12345678A" };
                ValidatePatternUsingLambda(passwordPattern, passwordInputs,"Password");



            }
        }
    }
