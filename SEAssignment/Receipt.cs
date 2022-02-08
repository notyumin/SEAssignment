using System;
using System.Collections.Generic;

public class Receipt
{
	private decimal amount;
	private string status; // "Refunded", "Paid", "Unpaid"
	private int pointsEarned;
	private Ride ride;

	private List<Payment> paymentList;

	public Receipt(Ride r)
	{
		status = "Unpaid";
		pointsEarned = 0;
		ride = r;

		paymentList = new List<Payment>();

	}

	int calculatePoints()
    {
		// implementation for points calculation
		return pointsEarned; // when printing receipt after completed ride, add points to user 
	}

	public decimal Amount { get; set; }
	public string Status { get; set; }
	public int PointsEarned { get; set; }
	public Ride Ride {
		get
		{
			return ride;
		}
	}

	public List<Payment> PaymentList {
		get
		{
			return paymentList;
		}
	}

	public void addPayment(Payment p)
	{

		if (!paymentList.Contains(p))
		{
			paymentList.Add(p);
		}

	}
}
