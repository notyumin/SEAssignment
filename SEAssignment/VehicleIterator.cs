using System.Collections.Generic;

public class VehicleIterator : Iterator
{
    List<Vehicle> vehicles;
    int position;
    public VehicleIterator(List<Vehicle> v)
    {
        vehicles = v;
        position = 0;
    }
    public override bool hasNext()
    {
        if (position < vehicles.Count)
            return true;
        return false;
    }

    public override object next()
    {
        Vehicle value = vehicles[position];
        position++;
        return value;
    }

    public override void remove()
    {
        throw new System.NotImplementedException("Remove is not supported by VehicleIterator");
    }
}
