using System;
using System.Collections.Generic;

public class UserAccount : Observer
{

    private static int id;
    private List<Ride> rideList;
    private string name;
    private string contactNo;
    private string emailAddr;
    private double rating;

    public UserAccount(string n, string cNo, string eA)
    {
        // auto increment id
        name = n;
        contactNo = cNo;
        emailAddr = eA;
    }

    public void update(Subject s)
    {
        if (s is Ride)
        {
            Ride ride = (Ride) s;
            // Implementation of phone notification system
            Console.WriteLine("Ride has updated to status: " + ride.State.Name);
        }
    }

    public int Id { get; set; }
    public List<Ride> RideList { get; set; }
    public string Name { get; set; }
    public string ContactNo { get; set; }
    public string EmailAddr { get; set; }
    public double Rating { get; set; }

}