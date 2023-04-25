using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLayer
{
    public class Worker : IdentityUser
    {
        [Key]
        public override string Id { get; set; }
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

        //[Required]
        //public override string PhoneNumber { get; set; }
        [Required]
        public string Role { get; set; }
        //[Required]
       // public override string Email { get; set; }

        public Worker(string id, string name, string surname, string lastname, string password, string phoneNumber, string email, string role)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.LastName = lastname;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Role = role;
        }
        public Worker(string id, string name, string surname, string lastname, string password, string phoneNumber, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.LastName = lastname;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
        public Worker()
        {

        }

        public Worker(string userName, string email, string name) : base(userName)
        {
        }
    }
}
