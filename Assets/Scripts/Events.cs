using System;

public class Events
{
    public static Action achievmentsResProgressCheck;
    public static Action achievmentsChestProgressCheck;
    public static Action achievmentsBrawlersProgressCheck;

    public static void CallAchivmentsResProgressCheck()
    {
        achievmentsResProgressCheck?.Invoke();
    }

    public static void CallAchivmentsChestProgressCheck()
    {
        achievmentsChestProgressCheck?.Invoke();
    }

    public static void CallAchivmentsBrawlersProgressCheck()
    {
        achievmentsBrawlersProgressCheck?.Invoke();
    }
}
