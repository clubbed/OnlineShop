using System.Threading.Tasks;

namespace OnlineShop.Application.Caching
{
    public interface ICacheService
    {
        Task<bool> DeleteKeyAsync(string key);
        Task<bool> KeyExistsAsync(string key);
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);

        Task<T> GetValueAsync<T>(string key);
        Task<bool> SetValueAsync<T>(string key, T value);

    }
}
