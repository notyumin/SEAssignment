using System;

public class CustomerAccount : UserAccount
{

    private bool premium;
    private int points;

    public CustomerAccount(string n, string cNo, string eA) : base(n, cNo, eA)
    {
        premium = false;
        points = 0;
    }

    public bool Premium { get; set; }
    public int Points { get; set; }
}