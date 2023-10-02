using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
        private Book _validBook = new Book("ValidBog", 500) { Id = 1 };
        private Book _nullTitleBook = new Book() { Id = 2, Price = 400 };
        private Book _shortTitleBook = new Book("ST", 300) { Id = 3 };
        private Book _priceTooHighBook = new Book("Too High", 1200.05) { Id = 4 };
        private Book _defaultPriceBook = new Book() { Id = 5, Title = "default Price" };
        private Book _negativePriceBook = new Book("NegativePrice", -1) { Id = 6 };
        private Book _zeroPriceBook = new Book("ZeroPrice", 0) { Id = 7 };
        private Book _validBook2 = new Book("ValidBog2", 505) { Id = 8 };

        private IBooksRepository _booksRepo = new BooksRepository();
        private IBooksRepository _booksRepoFixed = new BooksRepository();

        [TestMethod()]
        public void AddTest()
        {
            // Test om de tilføjes og får unik id.
            Assert.AreEqual<int>(5, _booksRepo.Get().Count());
            Book abcd = _booksRepo.Add(new Book { Title = "abcd", Price = 600 });
            Book efgh = _booksRepo.Add(new Book { Title = "efgh", Price = 700 });
            Assert.IsNotNull(abcd.Id);
            Assert.IsNotNull(efgh.Id);
            Assert.AreNotEqual(abcd.Id, efgh.Id);
            Assert.IsTrue(abcd.Id < efgh.Id);
            Assert.AreEqual<int>(7, _booksRepo.Get().Count());


            //test validering ikke tillader tilføjelse af fejlede objekter
            Assert.ThrowsException<ArgumentNullException>(() => _booksRepo.Add(_nullTitleBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_shortTitleBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_priceTooHighBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_defaultPriceBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_negativePriceBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_zeroPriceBook));
            Assert.AreEqual<int>(7, _booksRepo.Get().Count());
        }

        [TestMethod()]
        public void GetTest()
        {

            //Test om Listen er den samme eller en kopi.
            List<Book> savedState = new List<Book>();
            savedState = _booksRepo.Get();
            _booksRepo.Delete(1);
            Assert.AreNotEqual(savedState.Count(), _booksRepo.Get().Count());
            Assert.AreEqual(5, savedState.Count());
            Assert.AreEqual(4, _booksRepo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // sikrer om de to repos er enige om det gældende objekt
            Assert.AreEqual(_booksRepoFixed.GetById(1).ToString(),_booksRepo.GetById(1).ToString());

            _booksRepo.Update(1, _validBook);
            // test om det nye objekt er ændret til det forventede
            Assert.AreNotEqual(_booksRepoFixed.GetById(1).ToString(), _booksRepo.GetById(1).ToString());
            Assert.AreEqual(_validBook.ToString(), _booksRepo.GetById(1).ToString());

            // Exeption hvis nye book fejler validering.
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Update(1, _negativePriceBook));

            // Hvis id ikke eksisterer i repo skal der returneres null
            Assert.IsNull(_booksRepo.Update(10, _validBook));
        }
    }
}