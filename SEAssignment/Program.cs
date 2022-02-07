using System;

namespace SEAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            // Cancel Booking Stuff
            DriverAccount driver = new DriverAccount("3000-3000-2000-4000", "Maybank", "Driver", "#65-93031902", "driver@gmail.com");
            Van van = new Van(50.30, 5.3, "Lalaland", "Mercedes?", "SIQOWE-2903");
            driver.Vehicle = van;

            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");

            Ride ride = new Ride("390392", "490290", DateTime.Now, customer);

            Receipt receipt = ride.Receipt;
            PaymentPoints payPoint = new PaymentPoints(receipt, "Booking Fee", 20);
            PaymentCreditCard payCC = new PaymentCreditCard("9403-9030-0943", receipt, "Booking Fee", 300.45);
            PaymentCreditCard payCC2 = new PaymentCreditCard("9403-9030-0943", receipt, "Deposit", 300.45);

            Console.WriteLine(payPoint.Amount);

            ride.setState(ride.RideDoneState);
            ride.cancelRide();

            ride.Driver = driver;
            ride.registerObserver(driver);

            ride.setState(ride.DriverAssignedState);
            ride.cancelRide();

        }
    }
}
