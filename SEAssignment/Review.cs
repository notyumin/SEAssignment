using System;

public class Review
{
    private static int id;
    private string description;
    private UserAccount reviewer;
    private UserAccount reviewee;

    public Review(string r, UserAccount er, UserAccount ee)
    {
        // auto increment id
        description = r;
        reviewer = er;
        reviewee = ee;
    }

    public int Id { get; set; }
    public string Description { get; set; }
    public UserAccount Reviewer { get; set; }
    public UserAccount Reviewee { get; set; }

}