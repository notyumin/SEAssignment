using System;

public abstract class  Payment
{
	protected string purpose; // Booking Fee, Trip Fare, Deposit
	protected decimal amount;
	protected string status; // A refunded receipt may not refund all payments
	protected Receipt receipt;

	public Payment(Receipt r, string p, decimal a)
    {
		receipt = r;
		purpose = p;
		amount = a;
		status = "Paid";
    }

	public abstract void pay();
	public abstract void refund();

    public string Purpose { get; set; }
	public decimal Amount { get; set; }
	public string Status { get; set; }
	public Receipt Receipt { get; set; }
}
