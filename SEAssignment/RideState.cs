using System;

public abstract class RideState
{

    protected Ride ride;
    protected string rideStateName;

    public RideState(Ride r, string n)
    {
        ride = r;
        rideStateName = n; // Easily identify what type of ride it is
    }

    public abstract void acceptRide();
    public abstract void cancelRide();
    public abstract void rateDriver();
    public abstract void rateCustomer();

    public Ride Ride
    {
        get
        {
            return ride;
        }
    }

    public string RideStateName
    {
        get
        {
            return rideStateName;
        }
    }

}
