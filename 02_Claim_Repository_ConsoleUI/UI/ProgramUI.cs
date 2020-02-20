using _02_Claims;
using ClaimsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Repository_ConsoleUI.UI
{
    public class ProgramUI
    {
        private Claim_Repository _claimRepository = new Claim_Repository();

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
                Console.WriteLine("Komodo Claims\n" +
                "Please choose an option:\n" +
                "1 - See All Claims \n" +
                "2 - Take Care Of Next Claim\n" +
                "3 - Enter A New Claim\n" +
                "4 - Exit");
                string userSelection = Console.ReadLine(); //getting user input
                switch (userSelection) //evaluating user input
                {
                    case "1":
                        GetAllClaims();
                        break;

                    case "2":
                        ManageNextClaim();
                        break;

                    case "3":
                        AddNewClaim();
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

        private void GetAllClaims()
        {
            Queue<Claims> claimQueue = _claimRepository.GetAllClaims();
            Console.WriteLine("Claim ID", "Claim Type", "Claim Description", "Claim Amount", "Date of Incident", "Claim Date", "Is Valid ?");
            {
                foreach (Claims claims in claimQueue)
                {
                    bool isValid = _claimRepository.ClaimIsValid(claims); //checks to see if valid, then displays in following order
                    Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}", claims.ClaimsID, claims.claimsType, claims.ClaimsDescription, claims.ClaimsAmount, claims.DateOfIncident, claims.DateOfClaim, isValid);
                }

                
            }

        }
    
        private void ManageNextClaim()
        {
            Queue<Claims> claimQueue = _claimRepository.GetAllClaims(); //pulls claims from respository
            Console.WriteLine("Here is the next claim:\n");
            Console.WriteLine($"Claim ID: {claimQueue.Peek().ClaimsID}"); // peek only views, does not remove from queue
            Console.WriteLine($"Claim Type: {claimQueue.Peek().claimsType}");
            Console.WriteLine($"Claim Description: {claimQueue.Peek().ClaimsDescription}");
            Console.WriteLine($"Claim Amount: ${claimQueue.Peek().ClaimsAmount}");
            Console.WriteLine($"Claim Incident Date: {claimQueue.Peek().DateOfIncident}");
            Console.WriteLine($"Claim Date: {claimQueue.Peek().DateOfClaim}");
            Console.WriteLine($"Claim Is Valid ? : {claimQueue.Peek().IsValid}");

            Console.WriteLine("Do you want to deal with this claim now?\n" +
                "Enter y for yes\n" +
                "Enter n for no");
            string userResponse = Console.ReadLine();
            if (userResponse == "y")
            {
                claimQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("Press any key");
                Console.ReadLine();
            }
        }
        private void AddNewClaim()
        {
            Claims newClaim = new Claims();
            Console.WriteLine("Please enter the Claim ID: ");
            newClaim.ClaimsID = int.Parse(Console.ReadLine()); //int Parse changes string to int

            Console.WriteLine("Please enter the number associated with the following Claim Types:\n" +
                "1 - Car\n" +
                "2 - House\n" +
                "3 - Theft");
            newClaim.claimsType = (ClaimsType)(int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter the Claim Description: ");
            newClaim.ClaimsDescription = (Console.ReadLine());

            Console.WriteLine("Enter the Claim Amount: ");
            newClaim.ClaimsAmount = decimal.Parse(Console.ReadLine()); //string changes to decimal

            Console.WriteLine("Enter the Claim Incident Date. Type date as follows: YYYY,MM,DD ");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine()); 

            Console.WriteLine("Enter the Claim Reported Date. Type date as follows: YYYY,MM,DD ");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
            string isValid;
            if (_claimRepository.ClaimIsValid(newClaim) == true) //evaluates timespan of entered dates
            {
                isValid = "Valid";
            }
            else
            {
                isValid = "Not Valid";
            }

            _claimRepository.AddNewClaim(newClaim); // new claim is added to repository and evaluated
            Console.WriteLine($"\nClaim ID: {newClaim.ClaimsID}\n" +
            $"Claim Type: {newClaim.claimsType}\n" +
            $"Claim Description: {newClaim.ClaimsDescription}\n" +
            $"Incident Date: {newClaim.DateOfIncident}\n" +
            $"Claim Date: {newClaim.DateOfClaim}\n" +
            $"This claim is: {isValid}\n");
        }

        private void SeedContent() //adding examples
        {
            Claims claimOne = new Claims(01, ClaimsType.car, "Crash", 50000.00m, new DateTime(2020, 1, 3), new DateTime(2019, 1, 1), true);
            Claims claimTwo = new Claims(02, ClaimsType.home, "Lighting Strike", 1000.00m, new DateTime(2020, 1, 2), new DateTime(2020, 2, 1), true);

            _claimRepository.AddNewClaim(claimOne);
            _claimRepository.AddNewClaim(claimTwo);
        }
    }
}
