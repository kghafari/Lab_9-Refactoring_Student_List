using System;
using System.Collections.Generic;

namespace Lab_9___Refactoring_the_Student_List_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Setup Lists 1. Student Name, 2. Favorite Food, 3. Hometown, 4. Favorite Color
            List<string> studentNames = new List<string>
            { "Kyle", "Jeffery", "Erika", "Thomas", "Albert"};
            
            List<string> homeTown = new List<string>
            { "Lansing", "Ann Arbor", "Trenton", "Cheboygan", "THE MOON" }; 
            
            List<string> favoriteFood = new List<string>
            { "Pizza", "Nachos", "Pasta", "Steak", "PEOPLE" };     
            
            List<string> favoriteColor = new List<string>
            { "Green", "Blue", "Red", "Black", "VOID" };

            //greeting
            Console.WriteLine("\tWelcome to the C# Student Info Database\n");

            //Ask user to select either a) 1. "List current students", OR b) "Add a new student"
            bool userContinue = true;
            while (userContinue)
            {

                bool userValidation1 = true;
                while (userValidation1)
                {
                    string firstSelection = GetUserInput("1. View Current Students\t2. Add New Student");
                    if (firstSelection == "1")
                    {
                        //list current students
                        PrintNamesInList(studentNames);

                        //Ask user to select a student
                        string studentNameInput = GetUserInput($"What student would you like to know more about? 1 - {studentNames.Count}");
                        int studentNameInputAsInt = int.Parse(studentNameInput) - 1;

                        //Ask "What would you like to know? {list options}
                        Console.WriteLine($"\nAlright, you have selected {studentNames[studentNameInputAsInt]}. What would you like to know? You can ask:");
                        Console.WriteLine("1. Hometown\t2. Favorite Food\t3.Favorite Color");

                        bool userValidation2 = true;
                        while (userValidation2)
                        {
                            //Get user input 
                            string moreInfoInput = Console.ReadLine();
                            if (moreInfoInput == "1")
                            {
                                //Print value stored
                                Console.WriteLine($"{studentNames[studentNameInputAsInt]}'s hometown is {homeTown[studentNameInputAsInt]}");
                                userValidation2 = false;
                            }
                            else if (moreInfoInput == "2")
                            {
                                //Print value stored
                                Console.WriteLine($"{studentNames[studentNameInputAsInt]}'s favorite food is {favoriteFood[studentNameInputAsInt]}");
                                userValidation2 = false;
                            }
                            else if (moreInfoInput == "3")
                            {
                                //Print value stored
                                Console.WriteLine($"{studentNames[studentNameInputAsInt]}'s favorite color is {favoriteColor[studentNameInputAsInt]}");
                                userValidation2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Please make a valid selection - 1 - 3");
                                userValidation2 = true;
                            }
                        }
                        userValidation1 = false;
                    }

                    else if (firstSelection == "2")
                    {
                        //receive Student input... add to Student list
                        Console.WriteLine("\nAlright, let's add a new student to the database.");
                        AddUserInputToList(studentNames, "Student Name: ");
                        AddUserInputToList(homeTown, "Hometown: ");
                        AddUserInputToList(favoriteFood, "Favorite Food: ");
                        AddUserInputToList(favoriteColor, "Favorite Color: ");                  
                        userValidation1 = false;
                    }
                    else
                    {
                        Console.WriteLine("Please make a valid selection - 1 or 2");
                        userValidation1 = true;
                    }
                }

                userContinue = KeepGoing("Would you like to continue? (y/n)", "n", "y");
            }
        }

        //User validation method. Requires GetUserInput method. 
        //message => "Would you like to add more? (y/n)"
        //option1 => "n", option2 => "y"
        public static bool KeepGoing(string message, string option1, string option2)
        {
            string keepGoing = GetUserInput(message);
            if (keepGoing == option1)
            {
                return false;
            }
            else if (keepGoing == option2)
            {
                return true;
            }
            else
            {

                return KeepGoing(message, option1, option2);
            }
        }

        public static void PrintNamesInList(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }
        }

        //Prompts user with 'message', and returns user input.
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        //Takes a list and prompt as input, and adds user response to list.
        public static void AddUserInputToList(List<string> stringList, string message)
        {
            string input = GetUserInput(message);
            stringList.Add(input);

            //OR
            //stringList.Add(GetUserInput(message));
        }
    }
}
