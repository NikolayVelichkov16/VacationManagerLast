using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace ServiceLayer
{
    public class DBManager<T, K>
    {
        private ICRUD<T, K> context;

        public DBManager(ICRUD<T, K> context)
        {
            this.context = context;
        }

        public void Create(T item)
        {
            try
            {
                context.Create(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public T Read(K key)
        {
            try
            {
                return context.Read(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<T> ReadAll()
        {
            try
            {
                return context.ReadAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(T item)
        {
            try
            {
                context.Update(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(K key)
        {
            try
            {
                context.Delete(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
