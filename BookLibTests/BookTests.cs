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
    public class BookTests
    {
        //[ClassInitialize]
        private Book _validBook = new Book("ValidBog", 500) { Id = 1 };
        private Book _nullTitleBook = new Book() { Id = 2, Price = 400 };
        private Book _shortTitleBook = new Book("ST", 300) { Id = 3 };
        private Book _priceTooHighBook = new Book("Too High", 1200.05) { Id = 4 };
        private Book _defaultPriceBook = new Book() { Id = 5, Title = "default Price" };
        private Book _negativePriceBook = new Book("NegativePrice", -1) { Id = 6 };
        private Book _zeroPriceBook = new Book("ZeroPrice", 0) { Id = 7 };
        [TestMethod]
        public void ToStringTest()
        {
            // ToString "Title: Abc, Price: 111."
            Assert.AreEqual("Title: ValidBog, Price: 500", _validBook.ToString());
            Assert.AreEqual("Title: ZeroPrice, Price: 0", _zeroPriceBook.ToString());

        }
        [TestMethod]
        public void TestName()
        {
            // not expecting exception, so if exception is thrown, test will fail.
            _validBook.ValidateName();
            _priceTooHighBook.ValidateName();

            //Expecting exceptions from these books
            Assert.ThrowsException<ArgumentException>(() => _shortTitleBook.ValidateName());
            Assert.ThrowsException<ArgumentNullException>(() => _nullTitleBook.ValidateName());

        }
        [TestMethod]
        public void TestPrice()
        {
            // not expecting exception, so if exception is thrown, test will fail.
            _validBook.ValidatePrice();
            _shortTitleBook.ValidatePrice();

            //Expecting exceptions from these books

            Assert.ThrowsException<ArgumentException>(() => _priceTooHighBook.ValidatePrice());
            Assert.ThrowsException<ArgumentException>(() => _defaultPriceBook.ValidatePrice());
            Assert.ThrowsException<ArgumentException>(() => _negativePriceBook.ValidatePrice());
            Assert.ThrowsException<ArgumentException>(() => _zeroPriceBook.ValidatePrice());

        }

        [TestMethod]
        public void TestValidate()
        {
            Assert.ThrowsException<ArgumentException>(() => _priceTooHighBook.Validate());
            Assert.ThrowsException<ArgumentException>(() => _negativePriceBook.Validate());
            Assert.ThrowsException<ArgumentException>(() => _zeroPriceBook.Validate());
            Assert.ThrowsException<ArgumentException>(() => _shortTitleBook.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => _nullTitleBook.Validate());
            Assert.ThrowsException<ArgumentException>(() => _defaultPriceBook.Validate());
        }
    }
}