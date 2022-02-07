using System;

public class PaymentPoints : Payment
{

	public PaymentPoints(Receipt r, string purp, decimal amt) : base(r, purp, amt) { }

	public override void pay() { }

	public override void refund()
	{
		if (receipt.Status != "Refunded")
		{
			receipt.Ride.Customer.Points += Convert.ToInt32(amount);
		}
	}
}
