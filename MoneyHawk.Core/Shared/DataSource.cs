using System.Linq;
using System;
using ServiceStack;

namespace MoneyHawk.Core
{
    using System.Collections.Generic;

    public abstract class DataSource<T>
    {
        protected readonly IServiceClient api;

        public DataSource(IServiceClient api)
        {
            this.api = api;
        }

        public abstract IEnumerable<T> GetAll();

    }
}