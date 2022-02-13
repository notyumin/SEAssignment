using System;
using System.Collections.Generic;

namespace SEAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();

        }

        static void Menu()
        {
            string input = "";
            while (input != "0")
            {
                Console.WriteLine(
                    "=== Main Menu ===\n" +
                    "\n" +
                    "[1] Register Driver\n" +
                    "[2] Make Booking (Customer)\n" +
                    "[3] Accept Booking (Driver)\n" +
                    "[4] Cancel Booking (Customer)\n" +
                    "[5] Make Payment (Customer)\n" +
                    "[6] Rate Customer/Driver\n" +
                    "[0] Exit\n"
                );

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RegisterDriver();
                        break;
                    case "2":
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
            Console.WriteLine("What is your bank account number: ");
            string bankNo = Console.ReadLine();

            Console.WriteLine("What is the name of the bank you are associated with:");
            string bankNa = Console.ReadLine();

            Console.WriteLine("What is your username: ");
            string username = Console.ReadLine();

            Console.WriteLine("What is your contact number: ");
            string contact = Console.ReadLine();

            Console.WriteLine("What is your email address: ");
            string email = Console.ReadLine();

            DriverAccount driver = new DriverAccount(bankNo, bankNa, username, contact, email);

            driver.RegisterVehicle();
        }

        static void MakeBooking()
        {

            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");
            Console.WriteLine("Make Booking\n");
            customer.makeBooking();

            Console.WriteLine("Searching for driver ................\n");
        }

        static void AcceptBooking()
        {
            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");

            DriverAccount driver = new DriverAccount("1111-2222-3333-4444", "OCBC", "jordie", "83749273", "jordie@gmail.com");

            Ride ride = customer.makeBooking();

            //Prompt user for state
            Console.WriteLine("What state would you like to execute the use case in?");
            Console.WriteLine(
                    "\n" +
                    "[1] RideRequestedState\n" +
                    "[2] DriverAssignedState\n" +
                    "[3] CustomerWaitingState\n" +
                    "[4] DriverArrivedState\n" +
                    "[5] RideStartedState\n" +
                    "[6] RideDoneState\n" +
                    "[7] CustomerCancelledState\n"
                );

            string opt;
            opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    ride.setState(ride.RideRequestedState);
                    break;

                case "2":
                    ride.setState(ride.DriverAssignedState);
                    break;

                case "3":
                    ride.setState(ride.CustomerWaitingState);
                    break;

                case "4":
                    ride.setState(ride.DriverArrivedState);
                    break;

                case "5":
                    ride.setState(ride.RideStartedState);
                    break;

                case "6":
                    ride.setState(ride.RideDoneState);
                    break;

                case "7":
                    ride.setState(ride.CustomerCancelledState);
                    break;

                default:
                    Console.WriteLine("Invalid input.\n");
                    break;
            }

            Console.WriteLine("\n[Configuring...] Setting Ride State");

            Console.WriteLine("Use Case: Accept Booking\n");

            Console.WriteLine("Do you accept the customer's booking? (Y/N):");
            string status = Console.ReadLine();

            if (status == "Y")
            {
                Console.WriteLine("Booking has been accepted");
            }

            if (status == "N")
            {
                Console.WriteLine("Booking has been rejected.");
                Console.WriteLine("Booking fee has been refunded back to the customer.");
            }
        }

        static void CancelBooking()
        {

            // Initializing Customer
            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");

            // Initializing Ride
            Console.WriteLine("Set start date to be 3 days beyond current date to test no deposit refund");

            Ride ride = customer.makeBooking();

            // Setting Ride State
            string input;
            bool valid;
            bool madePayment = true;

            valid = false;
            Console.WriteLine("");

            while (valid == false)
            {
                Console.WriteLine(
                    "=== Select a state ===\n" +
                    "\n" +
                    "[1] RideRequestedState\n" +
                    "[2] DriverAssignedState\n" +
                    "[3] CustomerWaitingState\n" +
                    "[4] DriverArrivedState\n" +
                    "[5] RideStartedState\n" +
                    "[6] RideDoneState\n" +
                    "[7] CustomerCancelledState\n" +
                    "\n" +
                    "Set-Up will automatically split full payment cost across payment methods"
                );

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        // Set state to ride requested
                        ride.setState(ride.RideRequestedState);
                        valid = true;
                        break;

                    case "2":

                        // Set state to driver assigned
                        ride.setState(ride.DriverAssignedState);
                        valid = true;
                        break;

                    case "3":

                        // Set state to customer waiting
                        ride.setState(ride.CustomerWaitingState);
                        valid = true;
                        break;

                    case "4":

                        // Set state to driver arrived
                        ride.setState(ride.DriverArrivedState);
                        valid = true;
                        break;

                    case "5":

                        // Set state to ride started
                        ride.setState(ride.RideStartedState);
                        valid = true;
                        break;

                    case "6":

                        // Set state to ride done
                        ride.setState(ride.RideDoneState);
                        valid = true;
                        break;

                    case "7":

                        // Set state to customer cancelled
                        ride.setState(ride.CustomerCancelledState);
                        valid = true;
                        break;

                    default:
                        // Invalid input
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }

            Console.WriteLine("");

            // Initalizing Driver
            // Initializing Vehicle for Driver

            valid = false;

            // Store payment amount for deposit and booking fee
            Dictionary<string, double> payment = new Dictionary<string, double>();

            while (valid == false)
            {
                Console.WriteLine(
                    "=== Select a vehicle ===\n" +
                    "\n" +
                    "[1] Car\n" +
                    "[2] Van\n" +
                    "[3] Excursion Bus\n"
                );

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        // Create Car Driver
                        DriverAccount carDriver = new DriverAccount("3000-3000-2000-4000", "Maybank", "CarDriver", "93031902", "CarDriver@gmail.com");

                        // Create Car
                        Car car = new Car("SMS8875K", "Tesla", "E0WQOE-1304");

                        // Set associations
                        carDriver.Vehicle = car;
                        ride.Driver = carDriver;

                        valid = true;
                        break;

                    case "2":

                        // Create Van Driver
                        DriverAccount vanDriver = new DriverAccount("2000-2000-2000-4000", "POSB", "VanDriver", "90203030", "VanDriver@gmail.com");

                        // Create Van
                        Van van = new Van(50.30, 4.30, "GTX3245X", "Mercedes", "SIQOWE-2903");

                        // Set up payment amount
                        payment.Add("Deposit", 50.30);
                        payment.Add("Booking Fee", 4.30);

                        // Set associations
                        vanDriver.Vehicle = van;
                        ride.Driver = vanDriver;

                        valid = true;
                        break;

                    case "3":

                        // Create Bus Driver
                        DriverAccount busDriver = new DriverAccount("3000-4000-3000-4000", "OCBC", "BusDriver", "93223030", "BusDriver@gmail.com");

                        // Create Bus
                        ExcursionBus bus = new ExcursionBus(35.30, "GFL42805X", "Mercedes", "SIQOWE-2903");

                        // Set up payment amount
                        payment.Add("Deposit", 35.30);

                        // Set associations
                        busDriver.Vehicle = bus;
                        ride.Driver = busDriver;

                        valid = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }

            Console.WriteLine("");

            // Initalizing receipt's payments
            valid = false;

            Receipt receipt = ride.Receipt;

            if (madePayment == true)
            {
                while (valid == false)
                {
                    Console.WriteLine(
                        "=== Select a payment method ===\n" +
                        "\n" +
                        "[1] Gift Card\n" +
                        "[2] Points\n" +
                        "[3] Credit Card\n" +
                        "[4] Gift Card & Credit Card\n" +
                        "[5] Points & Credit Card\n" +
                        "[6] No Payment (Mainly applicable for ride requested state) \n" +
                        "\n" +
                        "Set-Up will automatically split full payment cost across payment methods"
                    );

                    input = Console.ReadLine();

                    // Create sample gift card
                    GiftCard giftCard = new GiftCard(1000.00);

                    switch (input)
                    {
                        case "1":

                            // Pay by gift card
                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentGiftCard payGift = new PaymentGiftCard(giftCard, receipt, item.Key, item.Value);
                            }

                            valid = true;
                            break;

                        case "2":

                            // Pay by points
                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentPoints payPoint = new PaymentPoints(receipt, item.Key, item.Value);
                            }
                            valid = true;
                            break;

                        case "3":

                            // Pay by credit card
                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentCreditCard payCC = new PaymentCreditCard("4039 4810 9302 9403", receipt, item.Key, item.Value);
                            }

                            valid = true;
                            break;

                        case "4":

                            // Pay by gift card and credit card
                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentGiftCard payGift = new PaymentGiftCard(giftCard, receipt, item.Key, item.Value / 2);
                                PaymentCreditCard payCC = new PaymentCreditCard("4039 4810 9302 9403", receipt, item.Key, item.Value /2);
                            }

                            valid = true;
                            break;

                        case "5":

                            // Pay by points and credit card
                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentPoints payPoint = new PaymentPoints(receipt, item.Key, item.Value / 2);
                                PaymentCreditCard payCC = new PaymentCreditCard("4039 4810 9302 9403", receipt, item.Key, item.Value /2);
                            }

                            valid = true;
                            break;

                        case "6":

                            // No payment
                            valid = true;
                            break;

                        default:
                            Console.WriteLine("Invalid input.\n");
                            break;
                    }
                }
            }

            // Cancel Ride
            ride.cancelRide();

            // Print general data
            Console.WriteLine("");
            Console.WriteLine("Print Showcase");
            Console.WriteLine("Receipt Status " + receipt.Status);

            // Print payment refund data
            foreach (Payment item in receipt.PaymentList)
            {
                string method = "";
                if (item is PaymentCreditCard)
                {
                    method = "Credit Card Payment";
                }
                else if (item is PaymentGiftCard)
                {
                    method = "Gift Card Payment";
                }
                else if (item is PaymentPoints)
                {
                    method = "Points Payment";
                }
                Console.WriteLine(method + " for " + item.Purpose + ": " + item.Status);
            }

            Console.WriteLine("");
        }

        static void MakePayment()
        {
            Console.WriteLine("Make Payment\n");
            //Data for testting
            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");
            customer.Premium = true;
            DateTime dt = new DateTime(2022, 02, 15);
            Ride ride = new Ride("621431", "632123", dt, customer);
            Receipt receipt = ride.Receipt;
            string purpose = "Fare";
            double fare = 50.30;
            //bool complete = false;
            PaymentCreditCard payCC = new PaymentCreditCard("4039 4810 9302 9403", receipt, purpose, fare);
            Console.WriteLine(
                        "=== Total Costs ===\n" +
                        "\n" +
                        "{0}: ${1}\n", purpose, fare
                    );
            Console.Write(
                        "=== Payment Methods ===\n" +
                        "\n" +
                        "[1] Credit Card\n" +
                        "[2] PickUpNow Points\n" +
                        "[3] Gift Card\n" +
                        "\n" +
                        "Please select payment method: "
                    );
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Write("Input credit card information: ");
                string ccNo = Console.ReadLine();

                if (ccNo == payCC.CreditCardNo)
                {
                    payCC.pay();
                    //complete = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid Payment Information\n");
                }
            }
            else if (input == "2")
            {
                PaymentPoints payPoints = new PaymentPoints(receipt, purpose, fare);
                if (customer.Premium == true)
                {
                    receipt.Ride.Customer.Points = 60;
                    //receipt.Ride.Customer.Points = 40; use to test insufficient points
                    payPoints.pay();
                }
                else
                {
                    Console.WriteLine("\nAccount is not Premium User");
                }
            }
            else if (input == "3")
            {
                GiftCard gc = new GiftCard(10);
                gc.Id = 10;
                PaymentGiftCard payGC = new PaymentGiftCard(gc, receipt, purpose, fare);
                Console.Write("Enter Gift Card ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id == gc.Id)
                {
                    payGC.pay();
                    Console.Write("Input credit card information: ");
                    string ccNo = Console.ReadLine();

                    if (ccNo == payCC.CreditCardNo)
                    {
                        payCC.pay();
                        //complete = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Payment Information\n");
                    }
                }
                else
                {
                    Console.WriteLine("Gift card does not exist");
                }

            }
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

            Console.WriteLine("[Initializing...] Add a few ratings to customer/driver");
            new Rating(4, customer, driver);
            new Rating(3, customer, driver);
            new Rating(2, driver, customer);
            new Rating(3, driver, customer);

            Console.WriteLine("[Initialising...] Customer Making Booking");
            customer.makeBooking();
            Ride ride = customer.RideList[0];
            Console.WriteLine("[Initialising...] Ride Created");

            ride.Driver = driver;
            Console.WriteLine("[Initialising...] Driver Assigned to Ride");

            //prompt user for state
            Console.WriteLine("What state would you like to execute the action in?");
            Console.WriteLine(
                    "\n" +
                    "[1] RideRequestedState\n" +
                    "[2] DriverAssignedState\n" +
                    "[3] CustomerWaitingState\n" +
                    "[4] DriverArrivedState\n" +
                    "[5] RideStartedState\n" +
                    "[6] RideDoneState\n" +
                    "[7] CustomerCancelledState\n"
                );

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":

                    ride.setState(ride.RideRequestedState);
                    break;

                case "2":
                    ride.setState(ride.DriverAssignedState);
                    break;

                case "3":
                    ride.setState(ride.CustomerWaitingState);
                    break;

                case "4":
                    ride.setState(ride.DriverArrivedState);
                    break;

                case "5":
                    ride.setState(ride.RideStartedState);
                    break;

                case "6":
                    ride.setState(ride.RideDoneState);
                    break;

                case "7":
                    ride.setState(ride.CustomerCancelledState);
                    break;

                default:
                    Console.WriteLine("Invalid input.\n");
                    break;
            }
            Console.WriteLine("\n[Configuring...] Setting Ride State");


            Console.WriteLine("\nRunning Use Case...");


            Console.WriteLine("\n[Use Case] Rate Driver/Customer");
            ride.rateCustomer();
            ride.rateDriver();
            Console.WriteLine();
        }
    }
}
