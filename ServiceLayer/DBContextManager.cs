using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class DBContextManager
    {
        private static ProjectDBContext _context;
        private static CEOContext _ceoContext;
        private static TeamContext _teamContext;
        private static TeamLeaderContext _teamleaderContext;
        private static VacationDocContext _vacationdocContextContext;

        public static ProjectDBContext CreateContext()
        {
            _context = new ProjectDBContext(new DbContextOptions<ProjectDBContext>());
            return _context;
        }

        public static ProjectDBContext GetProjectDBContext()
        {
            return _context;
        }

        //CEOContexts
        public static CEOContext CreateCEOContext(ProjectDBContext context)
        {
            _ceoContext = new CEOContext(context);
            return _ceoContext;
        }

        public static CEOContext GetCEOContext()
        {
            return _ceoContext;
        }
      

       

        //TeamContext
        public static TeamContext CreateTeamContext(ProjectDBContext context)
        {
            _teamContext = new TeamContext(context);
            return _teamContext;
        }

        public static TeamContext GetTeamContext()
        {
            return _teamContext;
        }

        //TeamLeaderContext
        public static TeamLeaderContext CreateTeamLeaderContext(ProjectDBContext context)
        {
            _teamleaderContext = new TeamLeaderContext(context);
            return _teamleaderContext;
        }
        public static TeamLeaderContext GetTeamLeaderContext()
        {
            return _teamleaderContext;
        }

        //VacationDocContext
        public static VacationDocContext CreateVacationDocContext(ProjectDBContext context)
        {
            _vacationdocContextContext = new VacationDocContext(_context);
            return _vacationdocContextContext;
        }
        public static VacationDocContext GetVacationDocContext()
        {
            return _vacationdocContextContext;
        }
    }
}
