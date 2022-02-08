using System;
using System.Collections.Generic;

public class Rating : Subject
{

    private static int id;
    private int stars;
    private UserAccount rater;
    private UserAccount ratee;

    private List<Observer> observers;

    public Rating(int r, UserAccount ter, UserAccount tee)
    {
        // auto increment id
        stars = r;
        rater = ter;
        ratee = tee;

        // add admin and ratee as observers
        AdminAccount admin = AdminAccount.getInstance();
        observers = new List<Observer>() { admin, tee };
        notifyObservers();
    }

    public int Id { get; set; }
    public int Stars { get; set; }
    public UserAccount Rater { get; set; }
    public UserAccount Ratee
    {
        get { return ratee; }
        set
        {
            if (ratee != value)
            {
                rater = value;
                value.addRating(this);
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
