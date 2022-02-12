using System;
using System.Collections.Generic;

public class Ride : Subject
{
    private int refNo;
    private double fare;
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

    private RideState rideCurrState;

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

        registerObserver(customer);
        setState(rideRequestedState);

        receipt = new Receipt(this);

        calculateEndTime();

        calculateFare();
    }

    public void setState(RideState s)
    {
        rideCurrState = s;
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
        {
            o.update(this);

        }
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
        rideCurrState.cancelRide();
    }

    public void rateCustomer()
    {
        rideCurrState.rateCustomer();
    }

    public void rateDriver()
    {
        rideCurrState.rateDriver();
    }

    public int RefNo
    {
        get
        {
            return refNo;
        }
        set
        {
            refNo = value;
        }
    }

    public double Fare
    {
        get
        {
            return fare;
        }
        set
        {
            fare = value;
        }
    }

    public string PickUpPoint
    {
        get
        {
            return pickUpPoint;
        }
        set
        {
            pickUpPoint = value;
        }
    }

    public string Destination
    {
        get
        {
            return destination;
        }
        set
        {
            destination = value;
        }

    }

    public DateTime StartTime
    {
        get
        {
            return startTime;
        }
        set
        {
            startTime = value;
        }
    }

    public DateTime EndTime
    {
        get
        {
            return endTime;
        }
        set
        {
            endTime = value;
        }

    }

    public DriverAccount Driver
    {
        get
        {
            return driver;
        }
        set
        {
            if (driver != value)
            {
                driver = value;
                value.addRide(this);
            }
        }
    }

    public CustomerAccount Customer
    {
        get
        {
            return customer;
        }
    }

    public RideState RideCurrState
    {
        get
        {
            return rideCurrState;
        }
        set
        {
            rideCurrState = value;
        }

    }

    public Receipt Receipt
    {
        get
        {
            return receipt;
        }
    }

    public RideState RideRequestedState
    {
        get
        {
            return rideRequestedState;
        }
    }

    public RideState DriverAssignedState
    {
        get
        {
            return driverAssignedState;
        }
    }

    public RideState CustomerCancelledState
    {
        get
        {
            return customerCancelledState;
        }
    }

    public RideState CustomerWaitingState
    {
        get
        {
            return customerWaitingState;
        }
    }

    public RideState DriverArrivedState
    {
        get
        {
            return driverArrivedState;
        }
    }

    public RideState RideStartedState
    {
        get
        {
            return rideStartedState;
        }
    }

    public RideState RideDoneState
    {
        get
        {
            return rideDoneState;
        }
    }
}
