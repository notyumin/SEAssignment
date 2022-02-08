using System;

public class RideRequestedState : RideState
{

    public RideRequestedState(Ride r, string n) : base(r, n) { }

    public override void cancelRide()
    {

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
