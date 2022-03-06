namespace DerivSmartRobot.Redis
{
    public static class CacheKeys
    {
        public static string GetMarketKey(string market)
        {
            return $"market:{market}";
        }
        
        public static string GetUserConfiguration(string token)
        {
            return $"user:{token}";
        }

        public static string GetQueueKey(string token)
        {
            return $"queue:{token}";
        }
    }
}