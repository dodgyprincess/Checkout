namespace CheckoutApp.Models
{
    public interface IItem
    {
        int Price { get; set; }
        string Name { get; set; }
        SpecialPrice Offer { get; set; }
    }
}