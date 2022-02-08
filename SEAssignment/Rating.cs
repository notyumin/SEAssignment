using System;
using System.Collections.Generic;

public class Rating : Subject
{

    private static int id;
    private int stars;
    private UserAccount rater;
    private UserAccount ratee;

    private List<Observer> observers;

    Rating(int r, UserAccount ter, UserAccount tee)
    {
        // auto increment id
        stars = r;
        rater = ter;
        ratee = tee;
        tee.addRating(this);

        // add admin and ratee as observers
        AdminAccount admin = AdminAccount.getInstance();
        observers = new List<Observer>() { admin, tee };
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
    public int Stars {
        get
        {
            return stars;
        }
        set
        {
            stars = value;
        }
    }
    public UserAccount Rater {
        get
        {
            return rater;
        }
    }

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
