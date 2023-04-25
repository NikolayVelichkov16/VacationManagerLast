using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLayer
{
    public class CEO 
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Company { get; set; }

        public CEO(Worker worker,string company)
        {
            this.Id = worker.Id;
            this.Name = worker.Name;
            this.Surname = worker.Surname;
            this.LastName = worker.LastName;
            this.Password = worker.Password;
            this.PhoneNumber = worker.PhoneNumber;
            this.Email = worker.Email;
            this.Company = company;
            this.Role = "CEO";
        }

        private CEO()
        {

        }
       


    }
}