using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {
        public int BadgeID { get; set; } //properties
        public List<string> ListOfDoors { get; set; }


        public Badge() { } //empty constructor
        public Badge(int badgeID,List<string> listOfDoors)
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors;
        }
    }
}
