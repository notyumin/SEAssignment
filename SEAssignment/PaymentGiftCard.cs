using System;

public class PaymentGiftCard : Payment
{
	private GiftCard giftCard;

	public PaymentGiftCard(GiftCard gift, Receipt r, string p, decimal a) : base(r, p, a) {
		giftCard = gift;
	}

	public override void pay() { }

	public override void refund() {
		if (receipt.Status != "Refunded")
		{
			giftCard.Amount += amount;
		}
	}

	public GiftCard Giftcard { get; set; }
}
