﻿using System;
using System.Collections.Generic;

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
            /*  // Cancel Booking Stuff
             DriverAccount driver = new DriverAccount("3000-3000-2000-4000", "Maybank", "Driver", "#65-93031902", "driver@gmail.com");
             Van van = new Van(50.30, 5.3, "Lalaland", "Mercedes?", "SIQOWE-2903");
             driver.Vehicle = van;

             CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");

             customer.makeBooking();
             Ride ride = customer.RideList[0];
             Receipt receipt = ride.Receipt;

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
            Console.WriteLine("Make Booking\n");
            //implementation here

            Console.WriteLine("What is your pick up point postal code: ");
            string pickuppoint = Console.ReadLine();

            Console.WriteLine("What is your drop off point postal code: ");
            string dropoffpoint = Console.ReadLine();

            Console.WriteLine("When do you want to schedule your ride(format in example {Feb 14, 2022} ):");
            string dateInput = Console.ReadLine();
            var parsedDate = DateTime.Parse(dateInput);
            Console.WriteLine(parsedDate);

            Ride ride = new Ride(pickuppoint, dropoffpoint, parsedDate);
            Console.WriteLine("Searching for driver ................\n");
        }

        static void AcceptBooking()
        {
            Console.WriteLine("Accept Booking\n");
            //implementation here
        }

        static void CancelBooking()
        {

            // General Set-Up for Cancel Booking

            CustomerAccount customer = new CustomerAccount("Cust", "93090429", "cust@gamil.com");

            Console.WriteLine("Set start date to be 3 days beyond current date to test no deposit refund");
            
            customer.makeBooking();

            Ride ride = null;
            string input;
            bool valid;
            bool madePayment = true;

            valid = false;

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

                        ride.setState(ride.RideRequestedState);
                        valid = true;
                        madePayment = false;
                        break;

                    case "2":

                        ride.setState(ride.DriverAssignedState);
                        valid = true;
                        break;

                    case "3":

                        ride.setState(ride.CustomerWaitingState);
                        valid = true;
                        break;

                    case "4":

                        ride.setState(ride.DriverArrivedState);
                        valid = true;
                        break;

                    case "5":

                        ride.setState(ride.RideStartedState);
                        valid = true;
                        break;

                    case "6":

                        ride.setState(ride.RideDoneState);
                        valid = true;
                        break;

                    case "7":

                        ride.setState(ride.CustomerCancelledState);
                        valid = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }

            input = "";
            valid = false;
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

                        DriverAccount carDriver = new DriverAccount("3000-3000-2000-4000", "Maybank", "CarDriver", "93031902", "CarDriver@gmail.com");
                        Car car = new Car("SMS8875K", "Tesla", "E0WQOE-1304");
                        carDriver.Vehicle = car;

                        ride = customer.RideList[0];
                        ride.Driver = carDriver;
                        valid = true;
                        break;

                    case "2":

                        DriverAccount vanDriver = new DriverAccount("2000-2000-2000-4000", "POSB", "VanDriver", "90203030", "VanDriver@gmail.com");
                        Van van = new Van(50.30, 4.30, "GTX3245X", "Mercedes", "SIQOWE-2903");
                        vanDriver.Vehicle = van;
                        payment.Add("Deposit", 50.30);
                        payment.Add("Booking Fee", 4.30);

                        ride = customer.RideList[0];
                        ride.Driver = vanDriver;
                        valid = true;
                        break;

                    case "3":

                        DriverAccount busDriver = new DriverAccount("3000-4000-3000-4000", "OCBC", "BusDriver", "93223030", "BusDriver@gmail.com");
                        ExcursionBus bus = new ExcursionBus(35.30, "GFL42805X", "Mercedes", "SIQOWE-2903");
                        busDriver.Vehicle = bus;

                        payment.Add("Deposit", 35.30);
                        ride = customer.RideList[0];
                        ride.Driver = busDriver;
                        valid = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }

            input = "";
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
                        "\n" +
                        "Set-Up will automatically split full payment cost across payment methods"
                    );

                    input = Console.ReadLine();

                    GiftCard giftCard = new GiftCard(1000.00);

                    switch (input)
                    {
                        case "1":

                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentGiftCard payGift = new PaymentGiftCard(giftCard, receipt, item.Key, item.Value);
                            }

                            valid = true;
                            break;

                        case "2":
                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentPoints payPoint = new PaymentPoints(receipt, item.Key, item.Value);
                            }
                            valid = true;
                            break;

                        case "3":
                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentCreditCard payCC = new PaymentCreditCard("4039 4810 9302 9403", receipt, item.Key, item.Value);
                            }

                            valid = true;
                            break;

                        case "4":

                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentGiftCard payGift = new PaymentGiftCard(giftCard, receipt, item.Key, item.Value / 2);
                                PaymentCreditCard payCC = new PaymentCreditCard("4039 4810 9302 9403", receipt, item.Key, item.Value);
                            }

                            valid = true;
                            break;

                        case "5":

                            foreach (KeyValuePair<string, double> item in payment)
                            {
                                PaymentPoints payPoint = new PaymentPoints(receipt, item.Key, item.Value / 2);
                                PaymentPoints payCC = new PaymentPoints(receipt, item.Key, item.Value / 2);
                            }

                            valid = true;
                            break;

                        default:
                            Console.WriteLine("Invalid input.\n");
                            break;
                    }
                }
            }

            ride.cancelRide();

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
        }

        static void MakePayment()
        {
            Console.WriteLine("Make Payment\n");
            //implementation here
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
