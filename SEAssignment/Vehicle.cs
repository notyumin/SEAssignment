using System;

public class Vehicle
{

    private string licencePlateNo;
    private string brand;
    private string model;
    private DriverAccount driver;

    public Vehicle(string plateNo, string vehBrand, string vehModel)
    {
        licencePlateNo = plateNo;
        brand = vehBrand;
        model = vehModel;
    }

    public string LicencePlateNo
    {
        get
        {
            return licencePlateNo;
        }
        set
        {
            licencePlateNo = value;
        }
    }
    public string Brand
    {
        get
        {
            return brand;
        }
        set
        {
            brand = value;
        }
    }

    public string Model
    {
        get
        {
            return model;
        }
        set
        {
            model = value;
        }
    }

    public DriverAccount Driver
    {
        get
        {
            return driver;
        }
        set
        {
            if (driver != value)
            {
                driver = value;
                value.Vehicle = this;
            }
        }
    }
}
