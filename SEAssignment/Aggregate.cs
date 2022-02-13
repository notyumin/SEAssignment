using System.Collections.Generic;

public abstract class Aggregate
{
    public abstract Iterator createIterator(List<DriverAccount> drivers, string vehicleType);
}
