using System;

public class Van : Vehicle
{
    private double deposit;

    private double bookingFee;

    public Van(double depo, double fee, string plateNo, string vehBrand, string vehModel) : base(plateNo, vehBrand, vehModel)
    {
        deposit = depo;
        bookingFee = fee;

    }

    public double Deposit
    {
        get
        {
            return deposit;
        }
        set
        {
            deposit = value;
        }
    }

    public double BookingFee
    {
        get
        {
            return bookingFee;
        }
        set
        {
            bookingFee = value;
        }

    }
}