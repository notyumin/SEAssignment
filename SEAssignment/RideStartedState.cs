﻿using System;

public class RideStartedState : RideState
{

    public RideStartedState(Ride r, string n) : base(r, n) { }

    public override void cancelRide()
    {
        Console.WriteLine("Ride is already underway. Ride can no longer be cancelled.");
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
