using System;
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

    // Add driver to ride back
    public override void addRide(Ride r)
    {
        if (!rideList.Contains(r))
        {
            rideList.Add(r);
            r.Driver = this;
        }
    }

    // Review should already have driver and should have no possibility of changing it (no set)
    public void addReview(Review r)
    {
        if (!reviewList.Contains(r))
        {
            reviewList.Add(r);
        }
    }

    public string BankAccNo
    {
        get
        {
            return bankAccNo;
        }
        set
        {
            bankAccNo = value;
        }
    }

    public string BankName
    {
        get
        {
            return bankName;
        }
        set
        {
            bankName = value;
        }
    }

    public double Amount
    {
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
            value.Driver = this;
        }

    }

    public void RegisterVehicle()
    {
        Console.WriteLine("Enter vehicle model (Car, Van, Excursion Bus):  ");
        string model = Console.ReadLine();

        Console.WriteLine("Enter vehicle brand:  ");
        string brand = Console.ReadLine();

        Console.WriteLine("Enter license plate number:  ");
        string plateNo = Console.ReadLine();

        Vehicle vehicle = new Vehicle(plateNo, brand, model);
    }
}
