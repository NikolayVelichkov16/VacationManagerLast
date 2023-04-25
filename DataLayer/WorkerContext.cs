using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class WorkerContext : ICRUD<Worker, string>
    {
        private ProjectDBContext _context;
        public WorkerContext(ProjectDBContext context)
        {
            this._context = context;
        }

        public void Create(Worker item)
        {

            try
            {
                Team team = _context.Teams.Find(item.TeamId);
                if (team != null)
                {
                    item.Team = team;
                }
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
                Worker devFromDB = Read(key);

                _context.Remove(devFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Worker Read(string key)
        {
            try
            {
                IQueryable<Worker> workerDB = _context.Workers;

                
                workerDB = workerDB.Include(w => w.Team);
                return workerDB.FirstOrDefault(w => w.Id == key);
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Worker> ReadAll()
        {
            try
            {
                return _context.Workers.Include(w => w.Team).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Worker item)
        {
            try
            {
                Worker devFromDB = Read(item.Id);

                _context.Entry(devFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
