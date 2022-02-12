using System;

public class PaymentPoints : Payment
{

	public PaymentPoints(Receipt r, string purp, double amt) : base(r, purp, amt) { }

	public override void pay() { }

	public override void payDriver()
	{
		receipt.Ride.Driver.Amount += Math.Round(amount * 0.9, 2); //assuming pickUpNow takes 10%
	}

	public override void refund()
	{
		if (receipt.Status != "Refunded")
		{
			receipt.Ride.Customer.Points += Convert.ToInt32(amount); // refund points
		}
	}
}
