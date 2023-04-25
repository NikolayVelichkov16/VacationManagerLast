using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Developer : Worker
    {
        public Developer(string id, string name, string surname, string lastname, string password, string phoneNumber, string email, int teamID, int rank)
            : base(id, name, surname, lastname, password, phoneNumber, email)
        {
            this.TeamID = teamID;
            this.Rank = rank;
        }
        private Developer() : base()
        {

        }
        public int TeamID { get; set; }
        public int Rank { get; set; }
    }
}
