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
        rideList = new List<Ride>();
    }

    public void update(Subject s)
    {
        if (s is Ride)
        {
            Ride ride = (Ride) s;

            // Implementation of phone notification system
            Console.WriteLine(name + "'s ride has updated it's status to: " + ride.RideCurrState.RideStateName);
        }
    }

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public List<Ride> RideList {
        get
        {
            return rideList;
        }
    }

    public abstract void addRide(Ride r);

    public string Name {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public string ContactNo {
        get
        {
            return contactNo;
        }
        set
        {
            contactNo = value;
        }
    }

    public string EmailAddr {
        get
        {
            return emailAddr;
        }
        set
        {
            emailAddr = value;
        }
    }

    public double Rating {
        get
        {
            return rating;
        }
        set
        {
            rating = value;
        }
    }

}