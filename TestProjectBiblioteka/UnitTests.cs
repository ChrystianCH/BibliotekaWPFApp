using BibliotekaWPFApp;

namespace TestProjectBiblioteka
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void BookToStringTest()
        {
            Book b = new Book("title1","author1",1);

            Assert.IsTrue(b.ToString().Contains("title1") && b.ToString().Contains("author1"));
        }

        [TestMethod]
        public void BorrowToStringTest()
        {
            Borrow b = new Borrow(1,1);

            Assert.IsTrue(b.ToString().Contains("Wypo¿yczono"));
        }

        [TestMethod]
        public void ClientToStringTest()
        {
            Client c = new Client("Jan", "Kowalski");

            Assert.IsTrue(c.ToString().Contains("Jan") && c.ToString().Contains("Kowalski"));
        }


        [TestMethod]
        public void CategoryToStringTest()
        {
            Category c = new Category("Krymina³");

            Assert.IsTrue(c.ToString().Contains("Krymina³"));
        }


    }
}