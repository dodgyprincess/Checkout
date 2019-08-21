using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutApp.Models;
using System.Linq;

namespace CheckoutTests
{
    [TestClass]
    public class UnitTest1
    {
        Item A = new Item("A", 50, new SpecialPrice(3, 130));
        Item B = new Item("B", 30 , new SpecialPrice(2, 45));
        Item C = new Item("C", 20);
        Item D = new Item("D", 15);

        [TestMethod]
        public void AOfferOneItem()
        {
            Checkout checkout = new Checkout();
            //Add 1 A Items to the checkout
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(A));
            Assert.AreEqual(A.Price, checkout.Total());
        }

        [TestMethod]
        public void AOfferOneCompleteOffer()
        {
            Checkout checkout = new Checkout();
            //Add 3 A Items to the checkout
            Enumerable.Range(0, 3).ToList().ForEach(x => checkout.Scan(A));
            Assert.AreEqual(A.Offer.Price, checkout.Total());
        }

        [TestMethod]
        public void AOfferOneItemOneCompleteOffer()
        {
            Checkout checkout = new Checkout();
            //Add 4 B Items to the checkout
            Enumerable.Range(0, 4).ToList().ForEach(x => checkout.Scan(A));
            Assert.AreEqual(A.Price + A.Offer.Price, checkout.Total());
        }

        [TestMethod]
        public void BOfferOneItem()
        {
            Checkout checkout = new Checkout();
            //Add 1 B Items to the checkout
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(B));
            Assert.AreEqual(B.Price, checkout.Total());
        }

        [TestMethod]
        public void BOfferOneCompleteOffer()
        {
            Checkout checkout = new Checkout();
            Enumerable.Range(0, 2).ToList().ForEach(x => checkout.Scan(B));
            Assert.AreEqual(B.Offer.Price, checkout.Total());
        }
        [TestMethod]
        public void BOfferTwoCompleteOffer()
        {
            Checkout checkout = new Checkout();
            Enumerable.Range(0, 4).ToList().ForEach(x => checkout.Scan(B));
            Assert.AreEqual(B.Offer.Price * 2, checkout.Total());
        }

        [TestMethod]
        public void BOfferOneItemOneCompleteOffer()
        {
            Checkout checkout = new Checkout();
            Enumerable.Range(0, 3).ToList().ForEach(x => checkout.Scan(B));
            Assert.AreEqual(B.Price+ B.Offer.Price, checkout.Total());
        }
        [TestMethod]
        public void COfferOneItem()
        {
            Checkout checkout = new Checkout();
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(C));
            Assert.AreEqual(C.Price, checkout.Total());
        }

        [TestMethod]
        public void DOfferOneItem()
        {
            Checkout checkout = new Checkout();
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(D));
            Assert.AreEqual(D.Price, checkout.Total());
        }

        [TestMethod]
        public void MultipleAAndBOffers()
        {
            Checkout checkout = new Checkout();
            //Add 9 A Items to the checkout total 3 offers for 390
            Enumerable.Range(0, 9).ToList().ForEach(x => checkout.Scan(A));
            //Add 4 B Items to the checkout total 2 offers for 90
            Enumerable.Range(0, 4).ToList().ForEach(x => checkout.Scan(B));
            Assert.AreEqual( 480, checkout.Total());
        }
        [TestMethod]
        public void OneOfEachItem()
        {
            Checkout checkout = new Checkout();
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(A));
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(B));
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(C));
            Enumerable.Range(0, 1).ToList().ForEach(x => checkout.Scan(D));
            Assert.AreEqual(A.Price + B.Price +C.Price + D.Price, checkout.Total());
        }

    }
}
