using System;

public class RideStartedState : RideState
{

	public RideStartedState(Ride r, string n) :base(r,n) {}

	public override void cancelRide()
    {
        Console.WriteLine("Ride is already underway. Ride can no longer be cancelled.");
    }

}