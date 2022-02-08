using System;

public class GiftCard
{

    private static int id;
    private double amount;

    public GiftCard(double amt)
    {
        // auto increment id
        amount = amt;
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
    public double Amount {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }

}