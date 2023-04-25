using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace BusinessLayer
{
    public class TeamLeader
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string LastName { get; set; }
      
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public List<VacationDoc> Vacations { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Email { get; set; }

        public TeamLeader(Worker worker)
        {
            this.Id = worker.Id;
            this.Name = worker.Name;
            this.Surname = worker.Surname;
            this.LastName = worker.LastName;
            this.Password = worker.Password;
            this.PhoneNumber = worker.PhoneNumber;
            this.Email = worker.Email;
            this.Role = "TeamLeader";
            this.TeamId = worker.TeamId;
            this.Team = worker.Team;
        }

        public TeamLeader()
        {

        }
      

    }
}