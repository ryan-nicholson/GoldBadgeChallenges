using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> ListOfBadges()
        {
            return _badgeDictionary;
        }

        public void AddNewBadge(Badge newBadge)
        {
            _badgeDictionary.Add(newBadge.BadgeID, newBadge.ListOfDoors);
        }

        public Badge GetBadgeByBadgeID(int badgeID)
        {
            foreach (KeyValuePair<int, List<string>> existingBadge in _badgeDictionary)
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
    }
}