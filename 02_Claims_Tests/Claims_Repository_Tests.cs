using System;
using _02_Claims;
using ClaimsClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    [TestClass]
    public class Claims_Repository_Tests
    {


        [TestMethod]
        public void TestAddNewClaim()
        {
            _claimRepo.AddNewClaim(_claim);
            int expected = 1;
            int actual = _claimRepo.GetAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }

        private Claim_Repository _claimRepo;
        private Claims _claim;

        [TestInitialize]

        public void Arrange()
            //creating fields
        {
            _claimRepo = new Claim_Repository();
            _claim = new Claims(1, ClaimsType.car, "test claim", 5000.00m, new DateTime(2020, 1, 1), new DateTime(2020, 2, 17), false);
        }

        [TestMethod]
        public void TestIsClaimValid()
        {
            //over 30 day claim
            _claimRepo.AddNewClaim(_claim);
            bool actual = _claimRepo.ClaimIsValid(_claim);
            bool expected = false;
            Assert.AreEqual(expected, actual);

        }
    }
}
