using System.Collections.Generic;
using System.Linq;

namespace CheckoutApp.Models
{
    public class Checkout : ICheckout
    {
        private Dictionary<Item, int> _basket;

        public Checkout()
        {
            _basket = new Dictionary<Item, int>();
        }
        public void Scan(Item item)
        {
            if (_basket.Keys.Contains(item))
            {
                _basket[item]++;
            }
            else
            {
                _basket.Add(item, 1);
            }

        }

        public int Total()
        {
            return  _basket.Keys.ToList().Select(item => 
            //Check item has an offer
            item.Offer == null ?
            //Calculate how many items there are and multiplies that amount by the individual item cost
            (_basket[item] * item.Price)  :
            //Calculate how many offer bundles the item qualifies for and multiplies that amount by the special offer cost
             (_basket[item] / item.Offer.Quantifier * item.Offer.Price) +
            //Calculate how many remaining items there are and multiplies that amount by the individual item cost
            (_basket[item] % item.Offer.Quantifier * item.Price)).Sum();
        }
    }
}
