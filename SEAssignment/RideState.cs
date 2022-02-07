using System;

public abstract class RideState
{

	protected Ride ride;
	protected string rideStateName;

    public RideState(Ride r, string n)
    {
        ride = r;
        rideStateName = n;
    }

	public abstract void cancelRide();
	
	public Ride Ride { 
        get {
            return ride;
        }
    }

    public string RideStateName { 
        get {
            return rideStateName;
        }
    }

}
