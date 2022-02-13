using System;
using System.Collections.Generic;

public class Receipt
{
	private double amount;
	private string status; // "Refunded", "Paid", "Unpaid"
	private int pointsEarned;
	private Ride ride;

	private List<Payment> paymentList;

	public Receipt(Ride r)
	{
		status = "Unpaid";
		pointsEarned = 0;

		// Receipt has a 1 to 1 "has a" association with ride
		// Upon construction, receipt should be linked to ride with no possible way of changing it (no set)
		ride = r;

		paymentList = new List<Payment>();

	}

	int calculatePoints()
    {
		// implementation for points calculation
		return pointsEarned; // when printing receipt after completed ride, add points to user 
	}

	public double Amount
	{
		get
		{
			return amount;
		}
		set
		{
			amount = value;
		}
	}

	public string Status
	{
		get
		{
			return status;
		}
		set
		{
			status = value;
		}
	}

	public int PointsEarned {
		get
		{
			return pointsEarned;
		}
		set
		{
			pointsEarned = value;
		}
	}

	// No set should be available, as it should be tied to the ride (not necessarily a weak entity)
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
