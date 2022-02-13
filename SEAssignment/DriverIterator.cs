using System;
using System.Collections.Generic;

public class DriverIterator : Iterator
{
    List<DriverAccount> drivers;
    int position;
    DateTime startTime;
    DateTime endTime;
    string vehicleType;

    public DriverIterator(List<DriverAccount> d, DateTime start, DateTime end, string vehicle)
    {
        drivers = d;
        position = 0;
        startTime = start;
        endTime = end;
        vehicleType = vehicle;

        while (position < drivers.Count)
        {
            if ((drivers[position].Vehicle is Car && vehicleType == "Car") || (drivers[position].Vehicle is ExcursionBus && vehicleType == "Excursion Bus") || (drivers[position].Vehicle is Van && vehicleType == "Van")){
                bool found = true;
                foreach (Ride ride in drivers[position].RideList)
                {
                    if (ride.RideCurrState.RideStateName != "Customer Cancelled" && ride.RideCurrState.RideStateName != "Customer Started" && ride.RideCurrState.RideStateName == "Customer Done")
                    {
                        if (startTime < ride.StartTime && endTime > ride.EndTime)
                        {
                            found = false;
                        }
                    }
                }
                if (found == true)
                {
                    break;
                }
            }
            position += 1;

        }
    }

    public override bool hasNext()
    {

        if (position < drivers.Count)
            return true;
        return false;

    }

    public override object next()
    {
        DriverAccount driver = drivers[position];
        position += 1;

        while (position < drivers.Count)
        {
            if ((drivers[position].Vehicle is Car && vehicleType == "Car") || (drivers[position].Vehicle is ExcursionBus && vehicleType == "Excursion Bus") || (drivers[position].Vehicle is Van && vehicleType == "Van"))
            {
                bool found = true;
                foreach (Ride ride in drivers[position].RideList)
                {
                    if (ride.RideCurrState.RideStateName != "Customer Cancelled" && ride.RideCurrState.RideStateName != "Customer Started" && ride.RideCurrState.RideStateName == "Customer Done")
                    {
                        if (startTime < ride.StartTime && endTime > ride.EndTime)
                        {
                            found = false;
                        }
                    }
                }
                if (found == true)
                {
                    break;
                }
            }
            position += 1;
        }

        return driver;
    }

    public override void remove()
    {
        throw new System.NotImplementedException("Remove is not supported by VehicleIterator");
    }
}
