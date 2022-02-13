using System;
using System.Collections.Generic;

public abstract class UserAccount : Observer
{

    protected static int id;
    protected List<Ride> rideList;
    protected string name;
    protected string contactNo;
    protected string emailAddr;
    protected double rating; // Derived attribute

    protected List<Rating> ratingList;

    public UserAccount(string username, string contact, string email)
    {
        // auto increment id
        name = username;
        contactNo = contact;
        emailAddr = email;
        rideList = new List<Ride>();
        ratingList = new List<Rating>();
        rating = 0;
    }

    public void update(Subject s)
    {
        // If change in state in ride
        if (s is Ride)
        {
            Ride ride = (Ride)s;

            // Implementation of phone notification system
            Console.WriteLine(name + "'s ride has updated it's status to: " + ride.RideCurrState.RideStateName);
        }

        // If new rating/ updated rating
        else if (s is Rating)
        {
            Rating rating = (Rating)s;

            //Implementation of Ratee update
            addRating(rating);
            updateAverageRating();
        }

        // If new review/ updated review
        else if (s is Review && this is DriverAccount)
        {
            Review review = (Review)s;

            //implementation of Reviewee update
            DriverAccount driver = (DriverAccount)this;
            driver.addReview(review);
        }
    }

    public void addRating(Rating r)
    {
        if (!ratingList.Contains(r))
        {
            ratingList.Add(r);
        }
    }

    // Calculate average rating
    public void updateAverageRating()
    {
        int totalStars = 0;
        foreach (var rating in ratingList)
        {
            totalStars += rating.Stars;
        }

        double averageStars = (double)totalStars / ratingList.Count;
        rating = averageStars;
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

    public List<Ride> RideList
    {
        get
        {
            return rideList;
        }
    }

    // AddRide is abstract as the methods neccessary for both should differ
    // Ride should already have customer and should have no possibility of changing
    public abstract void addRide(Ride r);

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public string ContactNo
    {
        get
        {
            return contactNo;
        }
        set
        {
            contactNo = value;
        }
    }

    public string EmailAddr
    {
        get
        {
            return emailAddr;
        }
        set
        {
            emailAddr = value;
        }
    }

    // Average is calculated upon update/ new rating
    // Should not have a set command for a derived attribute
    public double Rating
    {
        get
        {
            return rating;
        }
    }

}
