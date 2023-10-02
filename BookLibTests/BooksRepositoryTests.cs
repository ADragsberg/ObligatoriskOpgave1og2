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
        private List<Book> _testList = new List<Book>() { };
        private BooksRepository _booksRepo = new BooksRepository();
        [TestInitialize]
        
        [TestMethod()]
        public void AddTest()
        {
            _booksRepo.Add(_validBook);
            Assert.ThrowsException<ArgumentNullException>(() => _booksRepo.Add(_nullTitleBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_shortTitleBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_priceTooHighBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_defaultPriceBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_negativePriceBook));
            Assert.ThrowsException<ArgumentException>(() => _booksRepo.Add(_zeroPriceBook));
            Assert.AreEqual(1, _booksRepo.Get().Count());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}