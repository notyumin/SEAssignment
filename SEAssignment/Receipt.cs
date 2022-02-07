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
	}

	void calculatePoints()
    {
		// implementation for points calculation
	}

	public decimal Amount { get; set; }
	public string Status { get; set; }
	public int PointsEarned { get; set; }
	public Ride Ride { get; set; }
	public List<Payment> PaymentList { get; set; }
}
