using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using BusinessLayer;

namespace ServiceLayer
{
    public class VacationDocManager : IManager<VacationDoc, int>
    {
        private VacationDocContext _VacationDocContext;

        public VacationDocManager(ProjectDBContext context)
        {
            this._VacationDocContext = new VacationDocContext(context);
        }

        public void Create(VacationDoc item)
        {
            try
            {
                _VacationDocContext.Create(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _VacationDocContext.Delete(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public VacationDoc Read(int key)
        {
            try
            {
                return _VacationDocContext.Read(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<VacationDoc> ReadAll()
        {
            try
            {
                return _VacationDocContext.ReadAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(VacationDoc item)
        {
            try
            {
                _VacationDocContext.Update(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
