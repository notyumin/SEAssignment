﻿using System;

public class CustomerCancelledState : RideState
{

    public CustomerCancelledState(Ride r, string n) : base(r, n) { }

    public override void acceptRide()
    {
        // Pre-condition not met
        Console.WriteLine("Make another booking first!");
    }

    public override void cancelRide()
    {
        // Pre-condition not met
        Console.WriteLine("Ride already cancelled.");
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
