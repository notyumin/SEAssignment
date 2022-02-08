using System;

public class PaymentGiftCard : Payment
{
	private GiftCard giftCard;

	public PaymentGiftCard(GiftCard gift, Receipt r, string purp, double amt) : base(r, purp, amt) {
		giftCard = gift;
	}

	public override void pay() { }

	public override void refund() {
		if (receipt.Status != "Refunded")
		{
			giftCard.Amount += amount;
		}
	}

	public GiftCard GiftCard {
		get
		{
			return giftCard;
		}
		set
		{
			giftCard = value;
		}
	}
}
