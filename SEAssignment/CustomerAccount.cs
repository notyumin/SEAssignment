using System;

public class CustomerAccount : UserAccount
{

    private bool premium;
    private int points;

    public CustomerAccount(string username, string contact, string email) : base(username, contact, email)
    {
        premium = false;
        points = 0;
    }

    // Ride should already have customer and should have no possibility of changing it (no set)
    public override void addRide(Ride r)
    {
        if (!rideList.Contains(r))
        {
            rideList.Add(r);
        }

    }

    public bool Premium
    {
        get
        {
            return premium;
        }
        set
        {
            premium = value;
        }
    }

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }

    public Ride makeBooking()
    {
        //implementation here

        Console.WriteLine("What is your pick up point postal code: ");
        string pickuppoint = Console.ReadLine();

        Console.WriteLine("What is your drop off point postal code: ");
        string dropoffpoint = Console.ReadLine();

        Console.WriteLine("When do you want to schedule your ride(format in example {Feb 14, 2022} ):");
        string dateInput = Console.ReadLine();
        var parsedDate = DateTime.Parse(dateInput);
        Console.WriteLine(parsedDate);

        Ride ride = new Ride(pickuppoint, dropoffpoint, parsedDate, this);

        return ride;
    }
}
