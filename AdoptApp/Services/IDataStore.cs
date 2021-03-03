using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdoptApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool fRefresh = false);

        //Task<bool> AddCaseAsync(T child);
        //Task<bool> UpdateCaseAsync(T child);
        //Task<bool> DeleteCaseAsync(string id);
        //Task<T> GetCaseAsync(string id);
        //Task<IEnumerable<T>> GetCasesAsync(bool forceRefresh = false);
    }
}
