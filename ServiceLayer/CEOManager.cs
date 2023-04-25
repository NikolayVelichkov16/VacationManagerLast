using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;

namespace ServiceLayer
{
    public class CEOManager : IManager<CEO, string>
    {
        private CEOContext _CEOContext;

        public CEOManager(ProjectDBContext context)
        {
            this._CEOContext = new CEOContext(context);
        }

        public void Create(CEO item)
        {
            try
            {
                _CEOContext.Create(item);
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
                _CEOContext.Delete(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public CEO Read(string key)
        {
            try
            {
                return _CEOContext.Read(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<CEO> ReadAll()
        {
            try
            {
                return _CEOContext.ReadAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(CEO item)
        {
            try
            {
                _CEOContext.Update(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}