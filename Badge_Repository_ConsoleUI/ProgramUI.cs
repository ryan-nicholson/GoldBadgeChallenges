using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository_ConsoleUI
{
    public class ProgramUI
    {
        private Badge_Repository _badgeRepository = new Badge_Repository();

        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void Menu()
        {
            //display options to user
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Komodo Insurance\n" +
                "Please choose an option:\n" +
                "1 - Add a badge \n" +
                "2 - Edit a badge\n" +
                "3 - List all badges\n" +
                "4 - Exit");
                string userSelection = Console.ReadLine(); //getting user input
                switch (userSelection) //evaluating user input
                {
                    case "1":
                        ListByBadgeID();
                        break;

                    case "2":
                        AddNewBadge();
                        break;

                    case "3":
                        UpdatingExistingBadge();
                        break;

                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number from the selection.");
                        break;
                }
            }
        }

        private void ListByBadgeID()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepository.ListByBadgeID(badgeID, listOfDoors);
            Console.WriteLine("Badge ID", List<string>);
        }
        private void AddNewBadge()
        {
            Badge content = new Badge();
            Console.WriteLine("What is the number on the badge:");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to:");
            content.ListOfDoors = Console.ReadLine();

            Console.WriteLine("Do you want to add another door?\n" +
                "Enter y for yes\n" +
                "Enter n for no");
            string userResponse = Console.ReadLine();
            if (userResponse == "y")
            {
                Console.WriteLine("What is the number on the badge:");
                content.BadgeID = int.Parse(Console.ReadLine());

                Console.WriteLine("List a door that it needs access to:");
                content.ListOfDoors = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Press any key");
                Console.ReadLine();
            }


            _badgeRepository.AddNewBadge(content);
            Console.WriteLine("The badge was added! Press any key to return to the main menu");
            Console.ReadKey();
        }
    }
}  