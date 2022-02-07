using System;

public class PaymentPoints : Payment
{

	public PaymentPoints(Receipt r, string p, decimal a) : base(r, p, a) { }

	public override void pay() { }

	public override void refund()
	{
		if (receipt.Status != "Refunded")
		{
			receipt.Ride.Customer.Points += Convert.ToInt32(amount);
		}
	}
}
