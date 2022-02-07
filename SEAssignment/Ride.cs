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

	public Ride(string departing, string dropOffPoint, DateTime start, CustomerAccount cust)
	{
		pickUpPoint = departing;
		destination = dropOffPoint;
		startTime = start;

		customer = cust;
		customer.addRide(this);
		// auto increment ref no

		rideRequestedState = new RideRequestedState(this, "Ride Requested");
		driverAssignedState = new DriverAssignedState(this, "Driver Assigned");
		customerCancelledState = new CustomerCancelledState(this, "Customer Cancelled");
		customerWaitingState = new CustomerWaitingState(this, "Customer Waiting");
		driverArrivedState = new DriverArrivedState(this, "Driver Arrived");
		rideStartedState = new RideStartedState(this, "Ride Started");
		rideDoneState = new RideDoneState(this, "Ride Done");


		observers = new List<Observer>();

		setState(rideRequestedState);
		registerObserver(customer);

		receipt = new Receipt(this);
		Console.WriteLine(this.PickUpPoint);

		calculateEndTime();

		calculateFare();
	}

    public void setState(RideState s)
	{
		state = s;
		notifyObservers();
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

	public void calculateEndTime()
	{
		// implementation for end time calculation
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

	public DriverAccount Driver { 
		get
        {
			return driver;
        }
		
		set {
			if (driver != value) {
				driver = value;
				value.addRide(this);
			}
		} 
	}

	public CustomerAccount Customer { get; }

	public RideState State { get; set; }
	public Receipt Receipt { get; }

	public RideState RideRequestedState { get;}
	public RideState DriverAssignedState { get;}
	public RideState CustomerCancelledState { get;}
	public RideState CustomerWaitingState { get;}
	public RideState DriverArrivedState { get;}
	public RideState RideStartedState { get;}
	public RideState RideDoneState { get;}

}