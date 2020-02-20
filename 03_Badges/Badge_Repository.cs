using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge_Repository
    {
        private Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>(); //declaring a dictionary

      
        public void AddNewBadge(Badge newBadge) //adding new badge
        {
            badgeDictionary.Add(newBadge.BadgeID, newBadge.ListOfDoors);
        }

        public Dictionary<int, List<string>>BadgeList() //list all badges
        {
            return badgeDictionary;
        }

        public Badge ListByBadgeID(int badgeID) //get door info with badge id
        {
            foreach (KeyValuePair<int, List<string>> existingBadge in badgeDictionary)
            {
                foreach (string door in existingBadge.Value)
                {
                    if (existingBadge.Key == badgeID)
                    {
                        Badge badge = new Badge(existingBadge.Key, existingBadge.Value);
                        return badge;
                    }
                }
            }
            return null;
        }

        public bool UpdateExistingBadge(int originalAccess, Badge newAccess )
        {
            Badge accessNow = ListByBadgeID(originalAccess);
            if (accessNow != null)
            {
                accessNow.ListOfDoors = newAccess.ListOfDoors;
              
                return true;
            }
            return false;
        }
       
    }


}
