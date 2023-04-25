using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TeamContext : ICRUD<Team, int>
    {
        private ProjectDBContext _context;

        public TeamContext(ProjectDBContext context)
        {
            this._context = context;
        }

        public void Create(Team item)
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
                Team teamFromDB = Read(key);

                _context.Remove(teamFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Team Read(int key)
        {
            try
            {

                return _context.Teams.Include(t => t.Workers).Include(t => t.TeamLeader).FirstOrDefault(t => t.ID == key);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Team> ReadAll()
        {
            try
            {
                return _context.Teams.Include(t => t.Workers).Include(t => t.TeamLeader).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Team item)
        {
            try
            {
                Team teamFromDB = Read(item.ID);

                _context.Entry(teamFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
