using System;

public class Vehicle
{

    private string licencePlateNo;
    private string brand;
    private string model;

    public Vehicle(string plateNo, string vehBrand, string vehModel)
    {
        licencePlateNo = plateNo;
        brand = vehBrand;
        model = vehModel;
    }

    public string LicencePlateNo { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}