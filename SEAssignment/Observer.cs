using System;

public interface Observer
{

    // Send subject as a parameter for what type of subject
    // and to determine what kind of pull data is neccessary
    public void update(Subject s);
}
