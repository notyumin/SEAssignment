using System;

public class DriverAccount : UserAccount
{

    private string bankAccNo;
    private string bankName;
    private decimal amount;
    private Vehicle vehicle;

    public DriverAccount(string bankNo, string bankNa, string n, string cNo, string eA) : base(n, cNo, eA)
    {
        bankAccNo = bankNo;
        bankName = bankNa;
        amount = 0;
    }

    public string BankAccNo { get; set; }
    public string BankName { get; set; }

    public decimal Amount { get; set; }

    public Vehicle Vehicle { get; set; }

}