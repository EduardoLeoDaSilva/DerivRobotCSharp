using Newtonsoft.Json;
using StackExchange.Redis;

namespace DerivSmartRobot.Redis
{
    public class RedisService : ICacheService
    {
        private IDatabase Database { get; }
        public ConnectionMultiplexer Connection { get; }

        public RedisService(IDatabase db,
            ConnectionMultiplexer conn)
        {
            Database = db;
            Connection = conn;
        }

        public Task<long> IncrementAsync(string key)
        {
            return Database.StringIncrementAsync(key);
        }

        public Task<TimeSpan> PingAsync()
        {
            return Database.PingAsync();
        }

        #region Key Value

        public async Task<T> GetObjectAsync<T>(string key)
        {
            var json = await Database.StringGetAsync(key);

            if (json.IsNullOrEmpty)
            {
                return default;
            }

            var obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

        public Task<bool> SetObjectAsync(string key, object obj, TimeSpan? expire = null)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Database.StringSetAsync(key, json, expiry: expire);
        }

        public Task<bool> DeleteAsync(string key)
        {
            return Database.KeyDeleteAsync(key);
        }

        #endregion

        #region List

        public async Task<T> ListLeftPopAsync<T>(string key)
        {
            var value = await Database.ListLeftPopAsync(key);
            if (value.IsNullOrEmpty)
                return default(T);

            var obj = JsonConvert.DeserializeObject<T>(value);
            return obj;
        }

        public Task<long> ListLeftPushAsync(string key, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Database.ListLeftPushAsync(key, json);
        }

        public Task ListTrimAsync(string key, int length)
        {
            return Database.ListTrimAsync(key, 0, length);
        }

        public async Task<long> ListLengthAsync(string key)
        {
            return await Database.ListLengthAsync(key);
        }

        public async Task<List<T>> GetPopRangeObjectsAsync<T>(string key, int qty)
        {
            var list = new List<T>();

            for (var i = 0; i < qty; i++)
            {
                var obj = await this.ListLeftPopAsync<T>(key);
                list.Add(obj);
            }

            return list;
        }

        public async Task<List<T>> GetListObjectsAsync<T>(string key, int page, int qty)
        {
            var pag = (page - 1) * qty;
            var qtd = qty - 1;

            var values = await Database.ListRangeAsync(key, pag, qtd);
            var list = new List<T>();

            foreach (var json in values)
            {
                list.Add(JsonConvert.DeserializeObject<T>(json));
            }

            return list;
        }

        public Task<long> ListRightPushAsync(string key, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Database.ListRightPushAsync(key, json);
        }

        #endregion

        #region Hash

        public Task<bool> HashSetAsync(string key, string field, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Database.HashSetAsync(key, field, json);
        }

        public async Task<T> HashGetAsync<T>(string key, string field)
        {
            var value = await Database.HashGetAsync(key, field);

            if (!value.HasValue)
                return default(T);

            var obj = JsonConvert.DeserializeObject<T>(value);

            return obj;
        }

        public Task<bool> HashDelAsync(string key, string field)
        {
            return Database.HashDeleteAsync(key, field);
        }

        public Task<long> HashLengthAsync(string key)
        {
            return Database.HashLengthAsync(key);
        }

        public async Task<List<T>> HashGetAllObjects<T>(string key)
        {
            var hashsJson = await Database.HashValuesAsync(key);
            var serializeTasks = new List<Task<T>>();

            foreach (var json in hashsJson)
            {
                serializeTasks.Add(Task.Run(() =>
                {
                    var obj = JsonConvert.DeserializeObject<T>(json);
                    return obj;
                }));
            }

            var results = await Task.WhenAll(serializeTasks);
            var list = results.ToList();

            return list;
        }

        #endregion
    }
}