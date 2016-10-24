using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace BabyStore.DAL
{
    public class StoreDbConfiguration : DbConfiguration
    {
        public StoreDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient",
                () => new SqlAzureExecutionStrategy(5, TimeSpan.FromSeconds(30)));
        }
    }
}
