using System;

public class RideRequestedState : RideState
{

    public RideRequestedState(Ride r, string n) : base(r, n) { }

    public override void acceptRide()
    {
        //TODO (WH)
		string option = "N";
		
		while (option != "Y")
        {
			Console.WriteLine("Do you want to accept the customer's booking? (Y/N):");
			option = Console.ReadLine();

			switch (option)
            {
				case "Y":

					break;

				case "N":

					return;

				default:
					Console.WriteLine("Please enter either Y or N.");
					Console.WriteLine("");
					break;
            }
        }

		ride.setState(ride.DriverAssignedState);
        Console.WriteLine("You have accepted the booking.");
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

            // AF3: Driver has not accepted booking
            Console.WriteLine("Full payment will be refunded if any.");

        }
        // AF 2: Vehicle is an excursion bus
        else if (vehicle is ExcursionBus)
        {
            // Step 4: Display relevant amount
            ExcursionBus bus = (ExcursionBus)vehicle;
            Console.WriteLine("Deposit:" + bus.Deposit);

            // AF3: Driver has not accepted booking
            Console.WriteLine("Full payment will be refunded if any.");
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
