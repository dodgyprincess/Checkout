namespace CheckoutApp.Models
{
    public class SpecialPrice
    {
        public int Quantifier;
        public int Price;

        public SpecialPrice(int quantifier, int price)
        {
            this.Quantifier = quantifier;
            this.Price = price;
        }
    }
}
