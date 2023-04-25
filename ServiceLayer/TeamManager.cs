using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ServiceLayer
{
  public class TeamManager : IManager<Team, int>
    {
        private TeamContext _TeamContext;

        public TeamManager(ProjectDBContext context)
        {
            this._TeamContext = new TeamContext(context);
        }

        public void Create(Team item)
        {
            try
            {
                _TeamContext.Create(item);
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
                _TeamContext.Delete(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /*  public Team Read(int key)
          {
              try
              {

                  return _TeamContext.Read(key);
              }
              catch (Exception e)
              {

                  throw e;
              }
          }*/
        public Team Read(int id)
        {
            using (var context = new ProjectDBContext())
            {
                // Use the Include method to load the related Developers entities.
                return context.Teams.Include(t => t.Workers).SingleOrDefault(t => t.ID == id);
            }
        }

        public IEnumerable<Team> ReadAll()
        {
            try
            {
                return _TeamContext.ReadAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(Team item)
        {
            try
            {
                _TeamContext.Update(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
