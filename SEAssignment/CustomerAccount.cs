using System;

public class CustomerAccount : UserAccount
{

    private bool premium;
    private int points;

    public CustomerAccount(string n, string cNo, string eA) : base(n, cNo, eA)
    {
        premium = false;
        points = 0;
    }

    public bool Premium { get; set; }
    public int Points { get; set; }

    public void makeBooking()
    {
        
        Console.WriteLine("What is your pick up point postal code: ");
        string pickuppoint = Console.ReadLine();

        Console.WriteLine("What is your drop off point postal code: ");
        string dropoffpoint = Console.ReadLine();

        Ride ride = new Ride(pickuppoint, dropoffpoint, DateTime.Now);
        
    }
}