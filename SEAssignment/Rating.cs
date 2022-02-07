using System;

public class Rating
{

    private static int id;
    private int stars;
    private UserAccount rater;
    private UserAccount ratee;

    Rating(int r, UserAccount ter, UserAccount tee)
    {
        // auto increment id
        stars = r;
        rater = ter;
        ratee = tee;
    }

    public int Id { get; set; }
    public int Stars { get; set; }
    public UserAccount Rater { get; set; }
    public UserAccount Ratee { get; set; }

}