using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BabyStore.Utilities
{
    public static class AsyncPaging
    {
        public static async Task<List<T>> ReturnPages<T>(this IQueryable<T> inputCollection, int pageNumber, int pageSize)
        {
            return await inputCollection.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
