using System;
using System.Collections.Generic;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badge_Repository_Tests
{
    [TestClass]
    public class Badge_Repository_Tests
    {
        [TestMethod]
        public void TestAddNewBadge()
        {
            _badgeRepo.AddNewBadge(_badge);
            int expected = 1;
            int actual = _badgeRepo.BadgeList().Count;
            Assert.AreEqual(expected, actual);
        }

        private Badge_Repository _badgeRepo;
        private Badge _badge;

        [TestInitialize]

        public void Arrange()
        //creating fields
        {
            _badgeRepo = new Badge_Repository();
            _badge = new Badge(100, new List<string> { "A1, A2, A3" });
            _badgeRepo.AddNewBadge(_badge);
        }

        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            Badge newAccess = new Badge(100, new List<string> { "A1, A2, A3" });
            bool updateResult = _badgeRepo.UpdateExistingBadge(100, newAccess);

            Assert.IsTrue(updateResult);
        }

        
    }
}
