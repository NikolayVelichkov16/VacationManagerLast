using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using BusinessLayer;

namespace ServiceLayer
{
    public class TeamLeaderManager : IManager<TeamLeader, string>
    {
        private TeamLeaderContext _TeamLeaderContext;

        public TeamLeaderManager(ProjectDBContext context)
        {
            this._TeamLeaderContext = new TeamLeaderContext(context);
        }

        public void Create(TeamLeader item)
        {
            try
            {
                _TeamLeaderContext.Create(item);
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
                _TeamLeaderContext.Delete(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public TeamLeader Read(string key)
        {
            try
            {
                return _TeamLeaderContext.Read(key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<TeamLeader> ReadAll()
        {
            try
            {
                return _TeamLeaderContext.ReadAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(TeamLeader item)
        {
            try
            {
                _TeamLeaderContext.Update(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
