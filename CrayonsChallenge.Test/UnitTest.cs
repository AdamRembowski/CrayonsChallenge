using System.Drawing;

namespace CrayonsChallenge.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestClassLoadFromFile()
        {
            //arrange
            ShowMenu childMenu = new ShowMenu("Wybierz Dziecko:");             

            //act
            childMenu.PositionsMenuList.Clear(); 
            var loadFromFile = new LoadFromFile();
            List<Child>? childList = new List<Child>();
            loadFromFile.ActivateOption(ref childMenu, ref childList);

            //assert
            Assert.AreEqual(childList[0].Name,"Adam");
            Assert.AreEqual(childList[0].CollectionOfCrayons.Count,6);
            Assert.AreEqual(childMenu.PositionsMenuList.Count, 3);
        }

        [Test]
        public void TestClassShowMenu()
        {
            //arrange
            ShowMenu mainMenu = new ShowMenu("Wybierz Opcjê:");
            mainMenu.PositionsMenuList.Clear();
            mainMenu.PositionsMenuList.Add("Dodaj dziecko");
            mainMenu.PositionsMenuList.Add("Wybierz dziecko");
            mainMenu.PositionsMenuList.Add("Daj dziecku kredkê");
            mainMenu.PositionsMenuList.Add("Usuñ b³êdnie dodan¹ kredkê");
            mainMenu.PositionsMenuList.Add("Poka¿ statystyki");
            mainMenu.PositionsMenuList.Add("Poka¿ statystyki wszystkich");
            mainMenu.PositionsMenuList.Add("Zapisz do pliku");
            mainMenu.PositionsMenuList.Add("Wczytaj z pliku");
            mainMenu.PositionsMenuList.Add("Zakoñcz");

            //act

            //assert
            Assert.AreEqual(mainMenu.PositionsMenuList.Count, 9);

        }
        [Test]
        public void TestClassStatistics01()
        {
            //arrange
            Child child = new Child("Adam");
            child.GiveCrayon("niebieski");

            //act
            Statistics statistics = new Statistics(child);

            //assert
            Assert.AreEqual(statistics.Name, "Adam");
            Assert.AreEqual(statistics.CollectionOfCrayonsCount, 1);
            Assert.AreEqual(statistics.IsWinner, false);
            Assert.AreEqual(statistics.Score, 6);
        }
        [Test]
        public void TestClassStatistics02()
        {
            //arrange
            Child child = new Child("Adam");
            List<string> colors = new Crayons().Colors;
            foreach (string color in colors)
            {
                child.GiveCrayon(color);
            }

            //act
            Statistics statistics = new Statistics(child);

            //assert
            Assert.AreEqual(statistics.Name, "Adam");
            Assert.AreEqual(statistics.CollectionOfCrayonsCount, 16);
            Assert.AreEqual(statistics.IsWinner, true);
            Assert.AreEqual(statistics.Score, 100);
        }
    }
}