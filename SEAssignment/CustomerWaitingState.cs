using System;

public class CustomerWaitingState : RideState
{
    public CustomerWaitingState(Ride r, string n) : base(r, n) { }

    public override void acceptRide()
    {
        Console.WriteLine();
        Console.WriteLine("You have already accepted this booking and the customer is at the pickup point");
        Console.WriteLine();
    }

    public override void cancelRide()
    {
        Vehicle vehicle = ride.Driver.Vehicle;
        bool depositRefund = true;

        // Step 2: Check if the vehicle is a van
        if (vehicle is Van)
        {
            // Step 3-4: Display relevant amount
            Van van = (Van)vehicle;
            Console.WriteLine("Booking Fee:" + van.BookingFee);
            Console.WriteLine("Deposit:" + van.Deposit);

            // Step 5: Check if cancellation date is within 3 days before the ride
            DateTime currentDate = DateTime.Now;
            if (currentDate.AddDays(3) >= ride.StartTime)
            {
                // Step 6-7: Display deposit refund message
                depositRefund = false;
                Console.WriteLine("Deposit fee will not be refunded upon cancellation.");
            }
            // AF3: Cancellation beyond 3 days from ride
            else
            {
                Console.WriteLine("Full payment will be refunded.");
            }
        }
        // AF2: Vehicle is an excursion bus
        else if (vehicle is ExcursionBus)
        {
            // Step 4: Display relevant amount
            ExcursionBus bus = (ExcursionBus)vehicle;
            Console.WriteLine("Deposit:" + bus.Deposit);

            // Step 5: Check if cancellation date is within 3 days before the ride
            DateTime currentDate = DateTime.Now;
            if (currentDate.AddDays(3) >= ride.StartTime)
            {
                // Step 6-7: Display deposit refund message
                depositRefund = false;
                Console.WriteLine("Deposit fee will not be refunded upon cancellation.");
            }
            // AF3: Cancellation beyond 3 days from ride
            else
            {
                Console.WriteLine("Full payment will be refunded.");
            }
        }

        // Step 8: System prompts for confirmation
        string option = "N";
        while (option != "Y")
        {
            Console.WriteLine("Are you sure you want to cancel this booking? [Y/N]");
            option = Console.ReadLine();

            switch (option)
            {
                // Step 9: Customer confirms cancellation of booking
                case "Y":

                    break;

                // AF4: Customer exits confirmation
                case "N":

                    return;

                default:
                    Console.WriteLine("Invaid Response.");
                    Console.WriteLine("");
                    break;
            }
        }

        // Step 10: System updates ride's state to "Customer Cancelled"
        // Step 11-12: System notifies the driver and customer that the ride has been cancelled, observer state pattern
        ride.setState(ride.CustomerCancelledState); // observer pattern

        // Step 13-17, AF11: System iterates through receipt's payment
        // AF6: No payment made, skip loop
        foreach (var payment in ride.Receipt.PaymentList)
        {
            // Step 14, AF7: Refund amount
            if ((payment.Purpose == "Booking Fee") || (payment.Purpose == "Deposit" && depositRefund))
            {
                // Step 15-17, AF9, AF10
                payment.refund();
                payment.Status = "Refunded";
            }
            // AF8: Do not refund amount, pay driver instead
            else if (payment.Purpose == "Deposit" && depositRefund == false)
            {
                payment.payDriver();
            }
        }

        // Step 18-19: Update Status, Email receipt
        ride.Receipt.Status = "Refunded";
        // implement email receipt system

        // Step 20: Display ride cancelled
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
