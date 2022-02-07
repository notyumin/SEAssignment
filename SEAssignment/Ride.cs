using System;
using System.Collections.Generic;

public class Ride : Subject
{
	private int refNo;
	private decimal fare;
	private string pickUpPoint;
	private string destination;
	private DateTime startTime;
	private DateTime endTime;
	private Receipt receipt;

	private DriverAccount driver;
	private CustomerAccount customer;

	private RideState rideRequestedState;
	private RideState driverAssignedState;
	private RideState customerCancelledState;
	private RideState customerWaitingState;
	private RideState driverArrivedState;
	private RideState rideStartedState;
	private RideState rideDoneState;

	private RideState state;

	private List<Observer> observers; // user accounts

	public Ride(string departing, string dropOffPoint, DateTime start)
	{
		pickUpPoint = departing;
		destination = dropOffPoint;
		startTime = start;
		// auto increment ref no

		rideRequestedState = new RideRequestedState(this, "Ride Requested");
		driverAssignedState = new DriverAssignedState(this, "Driver Assigned");
		customerCancelledState = new CustomerCancelledState(this, "Customer Cancelled");
		customerWaitingState = new CustomerWaitingState(this, "Customer Waiting");
		driverArrivedState = new DriverArrivedState(this, "Driver Arrived");
		rideStartedState = new RideStartedState(this, "Ride Started");
		rideDoneState = new RideDoneState(this, "Ride Done");

		setState(rideRequestedState);

		observers = new List<Observer>();
	}

    public void setState(RideState s)
	{
		notifyObservers();
		state = s;

	}

	public void registerObserver(Observer o)
	{
		observers.Add(o);
	}

	public void removeObserver(Observer o)
	{
		observers.Remove(o);
	}

	public void notifyObservers()
	{
		foreach (Observer o in observers)
			o.update(this);
	}


	public void calculateFare()
	{
		// implementation for fare calculation
	}

	public void cancelRide()
    {
		state.cancelRide();
	}

	public int RefNo { get; set; }
	public decimal Fare { get; set; }
	public string PickUpPoint { get; set; }
	public string Destination { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }

	public DriverAccount Driver { get; set; }
	public CustomerAccount Customer { get; set; }

	public RideState State { get; set; }
	public Receipt Receipt { get; set; }

	public RideState RideRequestedState { get; set; }
	public RideState DriverAssignedState { get; set; }
	public RideState CustomerCancelledState { get; set; }
	public RideState CustomerWaitingState { get; set; }
	public RideState DriverArrivedState { get; set; }
	public RideState RideStartedState { get; set; }
	public RideState RideDoneState { get; set; }

}