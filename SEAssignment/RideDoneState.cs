﻿using System;

public class RideDoneState : RideState
{

    public RideDoneState(Ride r, string n) : base(r, n) { }

    public override void cancelRide()
    {
        Console.WriteLine("Ride is already completed. Ride can no longer be cancelled.");
    }

    public override void rateDriver()
    {
        Console.WriteLine("How was the ride? (1-5)");
        string starsInput = Console.ReadLine();
        int stars = Convert.ToInt32(starsInput);
        Rating rating = new Rating(stars, ride.Customer, ride.Driver);

        Console.WriteLine("Customer: Leave a review!");
        string feedback = Console.ReadLine();
        if (feedback != "")
        {
            Review customerReview = new Review(feedback, ride.Customer, ride.Driver);
        }
    }

    public override void rateCustomer()
    {
        Console.WriteLine("How was the ride? (1-5)");
        string starsInput = Console.ReadLine();
        int stars = Convert.ToInt32(starsInput);
        Rating rating = new Rating(stars, ride.Driver, ride.Customer);
    }
}
