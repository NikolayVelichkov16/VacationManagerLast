using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class WorkerManager : IManager<Worker, string>
    {
        private WorkerContext _WorkerContext;

        public WorkerManager(ProjectDBContext context)
        {
            this._WorkerContext = new WorkerContext(context);
        }

        public void Create(Worker item)
        {
            try
            {
                _WorkerContext.Create(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(string key)
        {
            try
            {
                _WorkerContext.Delete(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Worker Read(string key)
        {
            try
            {
                return _WorkerContext.Read(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<Worker> ReadAll()
        {
            try
            {
                return _WorkerContext.ReadAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(Worker item)
        {
            try
            {
                _WorkerContext.Update(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
