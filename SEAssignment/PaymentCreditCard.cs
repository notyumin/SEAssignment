using System;

public class PaymentCreditCard : Payment
{
	private string creditCardNo;

	public PaymentCreditCard(string creditNo, Receipt r, string purp, double amt) : base(r, purp, amt)
	{
		creditCardNo = creditNo;
	}

	public override void pay() { }

	public override void payDriver()
	{
		receipt.Ride.Driver.Amount += Math.Round(amount * 0.9, 2); // assuming pickUpNow takes 10%
	}

	public override void refund()
	{
		if (receipt.Status != "Refunded")
		{
			// implementation for credit card system refund
		}
	}

	public string CreditCardNo
	{
		get
		{
			return creditCardNo;
		}
		set
		{
			creditCardNo = value;
		}
	}
}
