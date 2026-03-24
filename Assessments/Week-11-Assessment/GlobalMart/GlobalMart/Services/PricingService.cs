namespace GlobalMart.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculatePrice(decimal basePrice, string promoCode)
        {
            if (promoCode == "WINTER25")
                return basePrice * 0.85m;
            if (promoCode == "FREESHIP")
                return basePrice - 5m;

            return basePrice;
        }
    }
}
