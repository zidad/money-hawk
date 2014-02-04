using System.Linq;
using System;

namespace MoneyHawk.Core
{
    using System.Collections.Generic;

    public abstract class DataSource<T>
    {
        protected readonly IMoneyBirdApi api;

        public DataSource(IMoneyBirdApi api)
        {
            this.api = api;
        }

        public abstract IEnumerable<T> GetAll();

    }
}