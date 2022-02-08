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

    private List<Rating> ratingList;

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
        if (s is Ride)
        {
            Ride ride = (Ride)s;

            // Implementation of phone notification system
            Console.WriteLine(name + "'s ride has updated it's status to: " + ride.RideCurrState.RideStateName);
        }

        if (s is Rating)
        {
            Rating rating = (Rating)s;

            //Implementation of Ratee update
            addRating(rating);
            updateAverageRating();
        }

        if (s is Review && this is DriverAccount)
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
            r.Ratee = this;
        }
    }

    public void updateAverageRating()
    {
        int totalStars = 0;
        foreach (var rating in ratingList)
        {
            totalStars += rating.Stars;
        }

        double averageStars = totalStars / ratingList.Count;
        rating = averageStars;
    }

    public int Id { get; set; }
    public List<Ride> RideList
    {
        get
        {
            return rideList;
        }
    }

    public abstract void addRide(Ride r);

    public string Name { get; set; }
    public string ContactNo { get; set; }
    public string EmailAddr { get; set; }
    public double Rating { get; set; }
}
