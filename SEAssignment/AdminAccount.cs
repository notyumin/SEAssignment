using System;

class AdminAccount : Observer
{
    public static AdminAccount uniqueInstance = null;

    private AdminAccount()
    {

    }

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
            Console.WriteLine($"Admin Notification: {rating.Ratee.Name} has received " +
                $"a {rating.Stars}-star rating from {rating.Rater.Name}");
        }

        if (s is Review)
        {
            Review review = (Review)s;
            //Implementation of Administrator update
            Console.WriteLine($"Admin Notification: {review.Reviewee.Name} has " +
                $"received the following review from {review.Reviewer.Name}: {review.Description}");
        }
    }
}
