using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public interface IManager<T, K>
    {
        void Create(T item);

        T Read(K key);

        IEnumerable<T> ReadAll();

        void Update(T item);

        void Delete(K key);
    }
}
