using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;

if (!OperatingSystem.IsWindows())
{
    Console.WriteLine("Dieses Beispiel funktioniert nur unter Windows.");
    return;
}

Console.WriteLine("Console App Notification Test");


AppNotificationManager.Default.NotificationInvoked += (_, args) =>
{
    Console.WriteLine($"Notification activated! Argument: {args.Argument}");
};
AppNotificationManager.Default.Register();

try
{
    var notification = new AppNotificationBuilder()
        .AddArgument("action", "viewItem")
        .AddText("Console Notification")
        .AddText("This was sent from a console app using Windows App SDK.")
        .BuildNotification();

    AppNotificationManager.Default.Show(notification);

    Console.WriteLine("Notification sent! Click it to test activation.");
    Console.WriteLine("Press Enter to exit.");
    Console.ReadLine();
}
finally
{
    AppNotificationManager.Default.Unregister();
}

