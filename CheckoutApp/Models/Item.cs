namespace CheckoutApp.Models
{
    public class Item : IItem
    {
        private string name;
        private int price;
        private SpecialPrice specialPrice;

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public SpecialPrice Offer { get => specialPrice; set => specialPrice = value; }

        public Item(string name, int price, SpecialPrice offer)
        {
            this.name = name;
            this.price = price;
            this.Offer = offer;
        }

        public Item(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}