using System;

public class Van: Vehicle
{
    private decimal deposit;

    private decimal bookingFee;

    public Van(decimal depo, decimal fee, string plateNo, string vehBrand, string vehModel): base(plateNo, vehBrand, vehModel)
    {
        deposit = depo;
        bookingFee = fee;
    }

    public decimal Deposit { get; set; }
    public decimal BookingFee { get; set; }

}