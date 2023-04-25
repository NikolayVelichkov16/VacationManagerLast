using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TeamLeaderContext : ICRUD<TeamLeader, string>
    {
        private ProjectDBContext _context;
        public TeamLeaderContext(ProjectDBContext context)
        {
            this._context = context;
        }

        public void Create(TeamLeader item)
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
                TeamLeader teamLeaderFromDB = Read(key);

                _context.Remove(teamLeaderFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TeamLeader Read(string key)
        {
            try
            {

                return _context.TeamLeaders.Include(tl => tl.Team).FirstOrDefault(tl => tl.Id == key);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TeamLeader> ReadAll()
        {
            try
            {
                return _context.TeamLeaders.Include(tl => tl.Team).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(TeamLeader item)
        {
            try
            {
                TeamLeader teamLeaderFromDB = Read(item.Id);

                _context.Entry(teamLeaderFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
