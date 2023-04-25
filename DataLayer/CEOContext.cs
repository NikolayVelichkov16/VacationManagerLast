using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class CEOContext : ICRUD<CEO, string>
    {
        private ProjectDBContext _context;
        public CEOContext(ProjectDBContext context)
        {
            this._context = context;
        }

        public void Create(CEO item)
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

        public void Delete(string key)
        {
            try
            {
                CEO ceoFromDB = Read(key);

                _context.Remove(ceoFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CEO Read(string key)
        {
            try
            {

                return _context.CEOs.Find(key);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CEO> ReadAll()
        {
            try
            {
                return _context.CEOs.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(CEO item)
        {
            try
            {
                CEO ceoFromDB = Read(item.Id);

                _context.Entry(ceoFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}