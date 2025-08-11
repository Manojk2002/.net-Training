using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_Mini_Project.Models
{

    public class Reservation
    {
        public int BookingId { get; set; }
        public int CustId { get; set; }
        public int TrainId { get; set; }
        public DateTime TravelDate { get; set; }
        public string ClassType { get; set; }
        public int SeatsBooked { get; set; }
        public string BerthAllotment { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDeleted { get; set; }
    }
}

