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

        // add admin and ratee as observers
        AdminAccount admin = AdminAccount.getInstance();
        observers = new List<Observer>() { admin, ee };
    }

    public int Id { get; set; }
    public string Description { get; set; }
    public CustomerAccount Reviewer { get; set; }
    public DriverAccount Reviewee
    {
        get { return reviewee; }
        set
        {
            if (reviewee != value)
            {
                reviewee = value;
                value.addReview(this);
            }
        }
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
