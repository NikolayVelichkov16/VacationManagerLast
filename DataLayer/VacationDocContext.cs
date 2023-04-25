using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class VacationDocContext : ICRUD<VacationDoc, int>
    {
        private ProjectDBContext _context;
        public VacationDocContext(ProjectDBContext context)
        {
            this._context = context;
        }

        public void Create(VacationDoc item)
        {

            try
            {
                _context.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                VacationDoc vacDocFromDB = Read(key);

                _context.Remove(vacDocFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VacationDoc Read(int key)
        {
            try
            {

                return _context.VacationDocs.Find(key);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<VacationDoc> ReadAll()
        {
            try
            {
                return _context.VacationDocs.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(VacationDoc item)
        {
            try
            {
                VacationDoc vacDocFromDB = Read(item.Id);

                _context.Entry(vacDocFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
