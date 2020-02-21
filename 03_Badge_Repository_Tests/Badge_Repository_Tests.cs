using System;
using System.Collections.Generic;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badge_Repository_Tests
{
    [TestClass]
    public class BadgeTests
    {
        private BadgeRepository _badgeRepository;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepository = new BadgeRepository();
            _badge = new Badge(100, new List<string> { "A1", "A2", "A3" });
        }

        [TestMethod]
        public void AddNewBadgeToListTest()
        {
            _badgeRepository.AddNewBadge(_badge);
            int expected = 1;
            int actual = _badgeRepository.ListOfBadges().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBadgeByBadgeIDTest()
        {
            _badgeRepository.AddNewBadge(_badge);
            Badge actual = _badgeRepository.GetBadgeByBadgeID(100);
            Assert.AreEqual(_badge.BadgeID, actual.BadgeID);
            Assert.AreEqual(_badge.ListOfDoors, actual.ListOfDoors);
        }
    }
}
