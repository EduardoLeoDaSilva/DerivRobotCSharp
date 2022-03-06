namespace DerivSmartRobot.Redis
{
    public interface ICacheService
    {
        Task<long> IncrementAsync(string key);
        Task<TimeSpan> PingAsync();
        Task<T> GetObjectAsync<T>(string key);
        Task<bool> SetObjectAsync(string key, object obj, TimeSpan? expire = null);
        Task<bool> DeleteAsync(string key);
        Task<T> ListLeftPopAsync<T>(string key);
        Task<long> ListLeftPushAsync(string key, object obj);
        Task ListTrimAsync(string key, int length);
        Task<long> ListLengthAsync(string key);
        Task<List<T>> GetPopRangeObjectsAsync<T>(string key, int qty);
        Task<List<T>> GetListObjectsAsync<T>(string key, int page, int qty);
        Task<long> ListRightPushAsync(string key, object obj);
        Task<bool> HashSetAsync(string key, string field, object obj);
        Task<T> HashGetAsync<T>(string key, string field);
        Task<bool> HashDelAsync(string key, string field);
        Task<long> HashLengthAsync(string key);
        Task<List<T>> HashGetAllObjects<T>(string key);
    }
}