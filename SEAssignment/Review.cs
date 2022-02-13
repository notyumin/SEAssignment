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

        // Rating has a 1 to 1 "has a" association with reviewer and reviewee
        // Upon construction, rating should be linked to reviewer and reviewee with no possible way of changing it (no set)
        reviewer = er;
        reviewee = ee;
        ee.addReview(this);

        // add admin and reviewee as observers
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

    // No set should be available, as it should be tied to the reviewer(not necessarily a weak entity)
    public CustomerAccount Reviewer {
        get
        {
            return reviewer;
        }
    }

    // No set should be available, as it should be tied to the reviewee (not necessarily a weak entity)
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
