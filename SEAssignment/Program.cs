using System;

namespace SEAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup Preconditions
            DriverAccount driver = new DriverAccount("3000-3000-2000-4000", "Maybank", "Driver", "#65-93031902", "driver@gmail.com");
            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");

            Menu();
            // Cancel Booking Stuff
            /* DriverAccount driver = new DriverAccount("3000-3000-2000-4000", "Maybank", "Driver", "#65-93031902", "driver@gmail.com");
            Van van = new Van(50.30, 5.3, "Lalaland", "Mercedes?", "SIQOWE-2903");
            driver.Vehicle = van;

            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");

            customer.makeBooking();
            Ride ride = customer.RideList[0];
            Receipt receipt = ride.Receipt;
            //manually assign driver
            ride.Driver = driver;

            //Ride ride = new Ride("390392", "490290", DateTime.Now, customer);
            //Receipt receipt = ride.Receipt;

            PaymentPoints payPoint = new PaymentPoints(receipt, "Booking Fee", 20);
            PaymentCreditCard payCC = new PaymentCreditCard("9403-9030-0943", receipt, "Booking Fee", 300.45);
            PaymentCreditCard payCC2 = new PaymentCreditCard("9403-9030-0943", receipt, "Deposit", 300.45);

            ride.rateCustomer();
            ride.rateDriver();
            ride.cancelRide();

            ride.setState(ride.RideDoneState);

            ride.rateCustomer();
            ride.rateDriver();
            ride.cancelRide();

            Console.WriteLine(payPoint.Status);

            ride.Driver = driver;
            ride.registerObserver(driver);

            ride.setState(ride.DriverAssignedState);
            ride.cancelRide();

            Console.WriteLine(payPoint.Status);
            Console.WriteLine(customer.Points); */
        }

        static void Menu()
        {
            string input = "";
            while (input != "0")
            {
                Console.WriteLine(
                    "[1] Register Driver\n" +
                    "[2] Make Booking (Customer)\n" +
                    "[3] Accept Booking (Driver)\n" +
                    "[4] Cancel Booking (Customer)\n" +
                    "[5] Make Payment (Customer)\n" +
                    "[6] Rate Customer/Driver\n" +
                    "[0] Exit\n" +
                    "[x] Testing Menu\n"
                );

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RegisterDriver();
                        break;
                    case "2":
                        Console.WriteLine("Make Booking\n");
                        MakeBooking();
                        break;
                    case "3":
                        AcceptBooking();
                        break;
                    case "4":
                        CancelBooking();
                        break;
                    case "5":
                        MakePayment();
                        break;
                    case "6":
                        RateAndReview();
                        break;
                    case "x":
                        TestingMenu();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }
        }

        static void RegisterDriver()
        {
            Console.WriteLine("Register Driver\n");
            //implementation here
        }

        static void MakeBooking()
        {
            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");
            customer.makeBooking();
        }

        static void AcceptBooking()
        {
            Console.WriteLine("Accept Booking\n");
            //implementation here
        }

        static void CancelBooking()
        {
            Console.WriteLine("Cancel Booking\n");
            //implementation here
        }

        static void MakePayment()
        {
            Console.WriteLine("Make Payment\n");
            //implementation here
        }

        static void RateAndReview()
        {
            Console.WriteLine("Use Case: Rate and Review\n");

            Console.WriteLine("Initialising pre-conditions...");
            //Create Customer
            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");
            Console.WriteLine("[Initialising...] Customer Account Created");
            //Create Driver
            DriverAccount driver = new DriverAccount("3000-3000-2000-4000", "Maybank", "Driver", "#65-93031902", "driver@gmail.com");
            Console.WriteLine("[Initialising...] Driver Account Created");

            Console.WriteLine("[Initialising...] Customer Making Booking");
            customer.makeBooking();
            Ride ride = customer.RideList[0];
            Console.WriteLine("[Initialising...] Ride Created");

            ride.Driver = driver;
            Console.WriteLine("[Initialising...] Driver Assigned to Ride");

            Console.WriteLine("\nRunning Use Case...");

            Console.WriteLine("\n[Use Case] Try to rate before ride is done");
            ride.rateCustomer(); //Ride is not completed. You may not leave a review yet.
            ride.rateDriver(); //Ride is not completed. You may not leave a review yet.

            Console.WriteLine("\n[Configuring...] Set ride to done");
            ride.setState(ride.RideDoneState);

            Console.WriteLine("\n[Use Case] Try to rate after ride is done");
            ride.rateCustomer();
            ride.rateDriver();
        }

        static void TestingMenu()
        {
            string input = "";
            while (input != "0")
            {
                Console.WriteLine(
                    "[1] Update Ride State\n" +
                    "[0] Exit back to Main Menu\n"
                );

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        UpdateRideState();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }
        }

        static void UpdateRideState()
        {
            Console.WriteLine("Update Ride State\n");
            Console.WriteLine(
                "[1] Update to RideRequestedState\n" +
                "[2] Update to DriverAssigneedState\n" +
                "[3] Update to CustomerCancelledState\n" +
                "[4] Update to CustomerWaitingState\n" +
                "[5] Update to DriverArrivedState\n" +
                "[6] Update to RideStartedState\n" +
                "[7] Update to RideDoneState\n"
            );

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //update state 
                    Console.WriteLine("Ride has been updated to RideRequestedState");
                    break;
                default:
                    break;
            }
        }
    }
}
