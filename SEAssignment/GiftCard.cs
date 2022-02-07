using System;

public class GiftCard
{

    private static int id;
    private decimal amount;

    public GiftCard(decimal a)
    {
        // auto increment id
        amount = a;
    }

    public int Id { get; set; }
    public decimal Amount { get; set; }

}