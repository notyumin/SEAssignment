using System;

public class RideDoneState : RideState
{

	public RideDoneState(Ride r, string n) :base(r,n) {}

    public override void cancelRide()
    {
        Console.WriteLine("Ride is already completed. Ride can no longer be cancelled.");
    }

}
