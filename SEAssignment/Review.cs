using System;
using System.Collections.Generic;

public class Review : Subject
{
    private static int id;
    private string description;
    private CustomerAccount reviewer;
    private DriverAccount reviewee;

    private List<Observer> observers;

    public Review(string r, CustomerAccount er, DriverAccount ee)
    {
        // auto increment id
        description = r;
        reviewer = er;
        reviewee = ee;
        ee.addReview(this);

        // add admin and ratee as observers
        AdminAccount admin = AdminAccount.getInstance();
        observers = new List<Observer>() { admin, ee };
        notifyObservers();
    }

    public int Id {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public string Description {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }

    public CustomerAccount Reviewer {
        get
        {
            return reviewer;
        }
    }

    public DriverAccount Reviewee
    {
        get { return reviewee; }
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

}
