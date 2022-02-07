using System;

public abstract class  Payment
{
	protected string purpose; // Booking Fee, Trip Fare, Deposit
	protected decimal amount;
	protected string status; // A refunded receipt may not refund all payments
	protected Receipt receipt;

	public Payment(Receipt r, string purp, decimal amt)
    {
		receipt = r;
		receipt.addPayment(this);

		purpose = purp;
		amount = amt;
		status = "Paid";

    }

	public abstract void pay();
	public abstract void refund();

    public string Purpose { get; set; }
	public decimal Amount { get; set; }
	public string Status { get; set; }
	public Receipt Receipt
	{
		get
		{
			return receipt;
		}

	}

}
