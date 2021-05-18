namespace Healthware.Assist.Core.Logging
{
    public static class LoggingExtensions
    {
        public static ILogger Log<T>(this T item_to_log)
        {
            return Logging.Log.For(item_to_log);
        }
    }
}