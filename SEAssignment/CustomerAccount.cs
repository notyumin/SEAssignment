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

    public override void addRide(Ride r)
    {
        if (!rideList.Contains(r))
        {
            rideList.Add(r);
            r.Customer = this;
        }

    }

    public bool Premium { get; set; }
    public int Points { get; set; }
}