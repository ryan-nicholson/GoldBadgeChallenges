using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public enum ClaimsType { car = 1, home, theft} // change to start at 1
    public class Claims
    {
        static void Main(string[] args)
        {

        }
        public int ClaimsID { get; set; }
        public ClaimsType claimsType { get; set; }
        public string ClaimsDescription { get; set; }
        public decimal ClaimsAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

    

        public Claims() { }

        public Claims(int claimsID, ClaimsType type, string claimsDescription, decimal claimsAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimsID = claimsID;
            claimsType = type;
            ClaimsDescription = claimsDescription;
            ClaimsAmount = claimsAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}

