using System;

namespace Project
{
    public class ParkingService
    {
        private readonly IDiscountService _discountService;

        public ParkingService(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        //hhh
        public double CalculateFee(int hours, string vehicleType)
        {
            double fee;

            if (vehicleType == "standard")
                if ((hours >= 1) && (hours < 3))
                    fee = hours * 4.0;
                else if (hours >= 9)
                    fee = hours * 3.0;
                else
                    fee = 0.0;
            else if (vehicleType == "electric")
                if ((hours >= 1) && (hours <= 5))
                    fee = hours * 3.0;
                else if (hours >= 6)
                    fee = hours * 2.0;
                else
                    fee = 0.0;
            else
                fee = 0.0;

            double discount = _discountService.GetDiscount();

            if (hours >= 10)
                fee = fee * discount;

            return fee;
        }
    }

    public interface IDiscountService
    {
        double GetDiscount();
    }

    public class DiscountService : IDiscountService
    {
        public double GetDiscount()
        {
            return 0.9;
        }
    }
}