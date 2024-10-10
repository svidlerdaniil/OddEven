using OddEvenServer;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetCurrentDateTime()
    {
        return DateTime.Now;
    }
}
