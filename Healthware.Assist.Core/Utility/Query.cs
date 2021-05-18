using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Healthware.Assist.Core.Utility
{
    public class Query<T> : IQueryable<T>
    {
        private readonly IQueryable<T> query;

        public Query(params T[] items)
        {
            query = items.AsQueryable();
        }

        public Expression Expression
        {
            get { return query.Expression; }
        }

        public Type ElementType
        {
            get { return query.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return query.Provider; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}