using System;

public abstract class RideState
{

	protected Ride ride;
	protected string name;

    public RideState(Ride r, string n)
    {
        ride = r;
        name = n;
    }

	public abstract void cancelRide();
	
	public Ride Ride { get; set; }

	public string Name { get; set; }

}
