using System.Threading.Tasks;

namespace MoneyHawk.Core
{
    using System.Collections.Generic;

    public abstract class DataSource<T>
    {
        protected readonly MoneyBirdClient client;

        public DataSource(MoneyBirdClient client)
        {
            this.client = client;
        }

        public abstract Task<IEnumerable<T>> GetAll();

    }
}