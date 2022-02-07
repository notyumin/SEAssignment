﻿using System;

public class PaymentGiftCard : Payment
{
	private GiftCard giftCard;

	public PaymentGiftCard(GiftCard gift, Receipt r, string purp, decimal amt) : base(r, purp, amt) {
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