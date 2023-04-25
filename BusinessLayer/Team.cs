using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Team
    {
       
        [Key]
        public int ID { get; set; }
        public List<Worker> Workers{ get; set; }
        public TeamLeader TeamLeader { get; set; }
        [Required]
        public string TeamName { get; set; }
       
        [Required]
        public string ProjectName { get; set; }
        public Team()
        {
            List<Worker> workers = new List<Worker>();  
        }
        public Team(List<Worker> workers, string teamName, string projectName)
        {
           
            Workers = workers;
            TeamName = teamName;
            ProjectName = projectName;
        }
        public Team(string teamName, string projectName)
        {
            Workers = new List<Worker>();
            TeamName = teamName;
            ProjectName = projectName;
        }
    }
}