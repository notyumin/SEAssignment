using System;
using System.Collections.Generic;

public abstract class UserAccount : Observer
{

    protected static int id;
    protected List<Ride> rideList;
    protected string name;
    protected string contactNo;
    protected string emailAddr;
    protected double rating;

    public UserAccount(string username, string contact, string email)
    {
        // auto increment id
        name = username;
        contactNo = contact;
        emailAddr = email;
    }

    public void update(Subject s)
    {
        if (s is Ride)
        {
            Ride ride = (Ride) s;
            // Implementation of phone notification system
            Console.WriteLine(name + "'s ride has updated it's status to: " + ride.State.Name);
        }
    }

    public int Id { get; set; }
    public List<Ride> RideList { get; }
    public abstract void addRide(Ride r);

    public string Name { get; set; }
    public string ContactNo { get; set; }
    public string EmailAddr { get; set; }
    public double Rating { get; set; }

}