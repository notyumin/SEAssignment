using System;
using System.Collections.Generic;

public class Rating : Subject
{

    private static int id;
    private int stars;
    private UserAccount rater;
    private UserAccount ratee;

    private List<Observer> observers;

    public Rating(int rate, UserAccount ter, UserAccount tee)
    {
        // auto increment id
        stars = rate;

        // Rating has a 1 to 1 "has a" association with rater and ratee
        // Upon construction, rating should be linked to rater and ratee with no possible way of changing it (no set)
        rater = ter;
        ratee = tee;

        tee.addRating(this);

        // add admin and ratee as observers
        AdminAccount admin = AdminAccount.getInstance();
        observers = new List<Observer>() { tee, admin };
        notifyObservers();
    }

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public int Stars
    {
        get
        {
            return stars;
        }
        set
        {
            stars = value;
        }
    }

    // No set should be available, as it should be tied to the rater (not necessarily a weak entity)
    public UserAccount Rater
    {
        get
        {
            return rater;
        }
    }

    // No set should be available, as it should be tied to the ratee (not necessarily a weak entity)
    public UserAccount Ratee
    {
        get { return ratee; }
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
