using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClass
{
    public class Claim_Repository
    {
        // creating queue of claims class instead of list
        private Queue<Claims> theClaims = new Queue<Claims>();

        // see all claims
        public Queue<Claims> GetAllClaims()
        {
            return theClaims;
        }
        //adding new claim and placing in the queue
        public void AddNewClaim(Claims newClaim)
        {
            theClaims.Enqueue(newClaim);
        }
        //finding number of days from incident to claim ( >< 30?)
        public bool ClaimIsValid(Claims claim)
        {
            TimeSpan daysInbetween = claim.DateOfClaim.Subtract(claim.DateOfIncident);
            if (daysInbetween.Days <= 30)
            {
                return true;
            }
            else            
            {
                return false;
            }
        }


  
    }



}
