using System;

public abstract class  Payment
{
	protected string purpose; // Booking Fee, Trip Fare, Deposit
	protected double amount;
	protected string status; // A refunded receipt may not refund all payments
	protected Receipt receipt;

	public Payment(Receipt r, string purp, double amt)
    {

		// Receipt has a 1 to many "has a" association with payment
		// Upon construction, payment should be added to the receipt with no possible way of changing it (no set)
		receipt = r;
		receipt.addPayment(this);

		purpose = purp;
		amount = amt;
		status = "Paid";

    }

	public abstract void pay();

	public abstract void payDriver();
	public abstract void refund();

    public string Purpose {
		get
		{
			return purpose;
		}
		set
		{
			purpose = value;
		}
	}

	public double Amount
	{
		get
		{
			return amount;
		}
		set
		{
			amount = value;
		}
	}

	public string Status
	{
		get
		{
			return status;
		}
		set
		{
			status = value;
		}
	}

	// No set should be available, as it should be tied to the receipt (not necessarily a weak entity)
	public Receipt Receipt
	{
		get
		{
			return receipt;
		}

	}

}
