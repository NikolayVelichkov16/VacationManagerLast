using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class VacationDoc
    {
        private VacationDoc()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="This is required")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "This is required")]
        public DateTime ToDate { get; set; }
        [Required(ErrorMessage = "This is required")]
        public DateTime CurrentDate { get; set; }

        public Worker Sender { get; set; }
        [Required(ErrorMessage = "This is required")]
        public int Type{ get; set; }
        [Required(ErrorMessage = "This is required")]
        public bool IsAccepted { get; set; } = false;
        [Required(ErrorMessage = "This is required")]
        public bool Pending { get; set; } = true;

        public byte[] ImageOfDoc { get; set; }


        public VacationDoc(DateTime fromDate, DateTime toDate, DateTime currentDate, Worker sender, int type)
        {
            FromDate = fromDate;
            ToDate = toDate;
            CurrentDate = DateTime.Now;
            Sender = sender;
            Type = type;
        }
        public VacationDoc(DateTime fromDate, DateTime toDate, DateTime currentDate, int type)
        {
            FromDate = fromDate;
            ToDate = toDate;
            CurrentDate = DateTime.Now;
           // Sender = sender;
            Type = type;
        }
    }
}