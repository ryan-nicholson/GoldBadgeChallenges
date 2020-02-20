using System;
using System.Collections.Generic;
using _01_KCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_KCafe_Tests
{
    [TestClass]
    public class Menu_Repository_Tests
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBoolean()
        {
            Meal content = new Meal();
            Menu_Repository repository = new Menu_Repository();

            bool addResult = repository.AddMealToMenu(content);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetMenu_ShouldReturnCorrectCollection()
        {
            Meal content = new Meal();
            Menu_Repository repo = new Menu_Repository();
            repo.AddMealToMenu(content);
            List<Meal> contents = repo.GetAllMeal();
            bool menuHasContent = contents.Contains(content);
            Assert.IsTrue(menuHasContent);
        }
        private Menu_Repository _repo;
        private Meal _content;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Menu_Repository();
            _content = new Meal("Grilled Cheese", 1, "Tasty white bread with melted american cheese", 5.00m, "white bread, cheese, butter");
            _repo.AddMealToMenu(_content);
        }
        [TestMethod]
        public void GetMealByName_ShouldReturnCorrectName()
        {
            Meal searchResult = _repo.GetMealByName("Grilled Cheese");
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void MyTestMethod()
        {
            bool removeResult = _repo.DeleteExistingMeal("Grilled Cheese");
            Assert.IsTrue(removeResult);
        }
    }
}
