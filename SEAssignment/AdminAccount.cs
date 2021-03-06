using System;

class AdminAccount : Observer
{
    // Singleton design pattern

    public static AdminAccount uniqueInstance = null;

    private AdminAccount() { }

    public static AdminAccount getInstance()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = new AdminAccount();
        }
        return uniqueInstance;
    }

    public void update(Subject s)
    {
        if (s is Rating)
        {
            Rating rating = (Rating)s;
            //Implementation of Administrator update
            Console.WriteLine($"\n[Admin Notification] {rating.Ratee.Name} has received " +
                $"a {rating.Stars}-star rating from {rating.Rater.Name}. Their new rating is {Math.Round(rating.Ratee.Rating, 2)}.");
        }

        if (s is Review)
        {
            Review review = (Review)s;
            //Implementation of Administrator update
            Console.WriteLine($"\n[Admin Notification] {review.Reviewee.Name} has " +
                $"received the following review from {review.Reviewer.Name}: {review.Description}");
        }
    }
}
