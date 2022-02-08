﻿using System;
using System.Collections.Generic;

public class DriverAccount : UserAccount
{

    private string bankAccNo;
    private string bankName;
    private double amount;
    private Vehicle vehicle;

    private List<Review> reviewList;

    public DriverAccount(string bankNo, string bankNa, string username, string contact, string email) : base(username, contact, email)
    {
        bankAccNo = bankNo;
        bankName = bankNa;
        amount = 0;
        reviewList = new List<Review>();
    }

    public override void addRide(Ride r)
    {
        if (!rideList.Contains(r))
        {
            rideList.Add(r);
            r.Driver = this;
        }
    }

    public void addReview(Review r)
    {
        if (!reviewList.Contains(r))
        {
            reviewList.Add(r);
            r.Reviewee = this;
        }
    }

    public string BankAccNo {
        get
        {
            return bankAccNo;
        }
        set
        {
            bankAccNo = value;
        }
    }

    public string BankName {
        get
        {
            return bankName;
        }
        set
        {
            bankName = value;
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

    public Vehicle Vehicle
    {
        get
        {
            return vehicle;
        }

        set
        {
            vehicle = value;
        }

    }
}
