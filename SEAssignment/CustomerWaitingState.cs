using System;

public class CustomerWaitingState : RideState
{
    public CustomerWaitingState(Ride r, string n) : base(r, n) { }

    public override void acceptRide()
    {
        Console.WriteLine("Currently waiting for a driver to accept your booking.");
    }

    public override void cancelRide()
    {
        Vehicle vehicle = ride.Driver.Vehicle;
        bool depositRefund = true;

        if (vehicle is Van)
        {
            Van van = (Van)vehicle;
            Console.WriteLine("Booking Fee:" + van.BookingFee);
            Console.WriteLine("Deposit:" + van.Deposit);
            DateTime currentDate = DateTime.Now;
            if (ride.StartTime.AddDays(3) >= currentDate)
            {
                depositRefund = false;
                Console.WriteLine("Deposit fee will not be refunded upon cancellation.");
            }

        }
        else if (vehicle is ExcursionBus)
        {
            ExcursionBus bus = (ExcursionBus)vehicle;
            Console.WriteLine("Deposit:" + bus.Deposit);
            DateTime currentDate = DateTime.Now;
            if (ride.StartTime.AddDays(3) >= currentDate)
            {
                depositRefund = false;
                Console.WriteLine("Deposit fee will not be refunded upon cancellation.");
            }
        }

        string option = "N";
        while (option != "Y")
        {
            Console.WriteLine("Are you sure you want to cancel this booking? [Y/N]");
            option = Console.ReadLine();

            switch (option)
            {
                case "Y":

                    break;

                case "N":

                    return;

                default:
                    Console.WriteLine("Invaid Response.");
                    Console.WriteLine("");
                    break;
            }
        }

        ride.setState(ride.CustomerCancelledState); // observer pattern

        foreach (var payment in ride.Receipt.PaymentList)
        {
            if ((payment.Purpose == "Booking Fee") || (payment.Purpose == "Deposit Fee" && depositRefund))
            {
                payment.refund();
                payment.Status = "Refunded";
            }
            else if (payment.Purpose == "Deposit Fee" && depositRefund == false)
            {
                payment.payDriver();
            }
        }

        // implement email receipt system

        ride.Receipt.Status = "Refunded";
        Console.WriteLine("Ride has been cancelled");
    }

    public override void rateCustomer()
    {
        Console.WriteLine("Ride is not completed. You may not leave a review yet. ");
    }

    public override void rateDriver()
    {
        Console.WriteLine("Ride is not completed. You may not leave a review yet. ");
    }
}
