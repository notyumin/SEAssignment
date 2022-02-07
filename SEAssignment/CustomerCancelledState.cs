using System;

public class CustomerCancelledState : RideState
{

 	public CustomerCancelledState(Ride r, string n) :base(r,n) {}

    public override void cancelRide()
    {
        Console.WriteLine("Ride already cancelled.");
    }

}
