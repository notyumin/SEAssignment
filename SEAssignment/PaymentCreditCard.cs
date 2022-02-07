using System;

public class PaymentCreditCard : Payment
{
	private int creditCardNo;

	public PaymentCreditCard(int creditNo, Receipt r, string p, decimal a) : base(r, p, a)
	{
		creditCardNo = creditNo;
	}

	public override void pay() { }

	public override void refund()
	{
		if (receipt.Status != "Refunded")
		{
			// implementation for credit card system refund
		}
	}

	public int CreditCardNo { get; set; }
}
