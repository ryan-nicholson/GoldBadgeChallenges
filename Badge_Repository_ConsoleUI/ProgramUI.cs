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
        private BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Insurance Badges\n" +
                "Make a selction from the menu:\n" +
                "1 - Add a Badge \n" +
                "2 - Update a Badge\n" +
                "3 - List all Badges\n" +
                "4 - Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        UpdateExistingBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddNewBadge()
        {
            Badge newBadge = new Badge();
            Console.Write("What is the new badge's numeric ID ? (ex: 12): ");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Write("Please enter a Door ID for this badge: ");
                newBadge.ListOfDoors = new List<string>();
                string userInput = Console.ReadLine().ToUpper();
                newBadge.ListOfDoors.Add(userInput);
                Console.Write("Any other doors to add ? (y/n)");
                string userResponse = Console.ReadLine();
                if (userResponse == "n")
                {
                    continueRunning = false;
                    _badgeRepository.AddNewBadge(newBadge);
                    Console.WriteLine($"\nYour new badge, Badge ID: {newBadge.BadgeID}, has been added.\n\n" +
                        $"Press any key to return to the main menu.");
                    Console.ReadKey();
                }
                else
                {
                    continueRunning = true;
                }
            }
        }
        private void ListAllBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepository.ListOfBadges();

            Console.WriteLine("{0, -10}", "BadgeID:");
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine(badge.Key);
                foreach (string door in badge.Value)
                {
                    Console.Write("{0} {1, -5}","", door);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void UpdateExistingBadge()
        {
            Console.Write("What is the badge number you would like to update ?: ");
            int userBadgeInput = int.Parse(Console.ReadLine());
            Badge badge = _badgeRepository.GetBadgeByBadgeID(userBadgeInput);
            foreach (string door in badge.ListOfDoors)
            {
                Console.WriteLine("{0, -10} {1, -10}", badge.BadgeID, door);
            }
            Console.WriteLine("What would you like to do ?\n" +
                "1 - Remove a door\n" +
                "2 - Add a door\n" +
                "3 - Cancel\n");
            string userResponse = Console.ReadLine();
            switch (userResponse)
            {
                case "1":
                    Console.WriteLine($"Which door would you like to remove?");
                    string removeDoor = Console.ReadLine().ToUpper();
                    badge.ListOfDoors.Remove(removeDoor);
                    Console.WriteLine($"Door {removeDoor} was removed from Badge {badge.BadgeID}");
                    break;

                case "2":
                    Console.WriteLine($"Which door would you like to add?");
                    string addDoor = Console.ReadLine().ToUpper();
                    badge.ListOfDoors.Add(addDoor);
                    Console.WriteLine($"Door {addDoor} was added to Badge {badge.BadgeID}");
                    break;

                case "3":
                    break;

                default:
                    Console.WriteLine("Invalid. Please try again...");
                    break;
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            Badge badgeOne = new Badge(10, new List<string> { "A1", "B1", "C1", "A2", "B2", "C2", });
            Badge badgeTwo = new Badge(11, new List<string> { "B1", "B2", "C1" });

            _badgeRepository.AddNewBadge(badgeOne);
            _badgeRepository.AddNewBadge(badgeTwo);

        }
    }

}