using System;

public class ExcursionBus: Vehicle
{
    private double deposit;

    public ExcursionBus(double depo, string plateNo, string vehBrand, string vehModel): base(plateNo, vehBrand, vehModel)
    {
        deposit = depo;
    }

    public double Deposit {
        get
        {
            return deposit;
        }
        set
        {
            deposit = value;
        }
    }

}