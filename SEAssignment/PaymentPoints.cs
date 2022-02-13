using System;

public class PaymentPoints : Payment
{

	public PaymentPoints(Receipt r, string purp, double amt) : base(r, purp, amt) { }

	public override void pay() {
		if (receipt.Status != "Refunded")
		{
			int userPoints = receipt.Ride.Customer.Points;
			//receipt.Ride.Customer.Points = Convert.ToInt32(amount); // refund points
			Console.WriteLine("\nPickUpNow Points: {0}", userPoints);
			Console.Write("\nWould you like to pay fully with point (Y/N)? ");
			string input = Console.ReadLine();
			if(input.ToUpper() == "Y")
            {
				if (userPoints< Convert.ToInt32(amount))
                {
					Console.WriteLine("Insufficient Points\n");
                }
                else
                {
					userPoints -= Convert.ToInt32(amount);
					Console.WriteLine("\nCurrent Amount of Points: {0}\n",userPoints);
				}
			}
			else if(input.ToUpper() == "N")
            {
				Console.Write("Input the amount of points you want to pay with: ");
				int points = Convert.ToInt32(Console.ReadLine());
				if(points > userPoints)
                {
					Console.WriteLine("\nInsufficient Points\n");
                }
                else
                {
					userPoints -= points;
					amount -= Convert.ToDouble(points);
					Console.WriteLine("=== Total Cost ===\n");
					Console.WriteLine("Current Amount of Points: {0}\n", userPoints);
					Console.WriteLine("Remaining Fare: {0}\n", amount);

					Console.Write("Input credit card information: ");
					string ccNo = Console.ReadLine();
					if (ccNo == "4039 4810 9302 9403")
					{
						Console.WriteLine("\nTransaction Successful\n");
					}
					else
					{
						Console.WriteLine("\nInvalid Payment Information\n");
					}
				}
			}
		}
	}

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
