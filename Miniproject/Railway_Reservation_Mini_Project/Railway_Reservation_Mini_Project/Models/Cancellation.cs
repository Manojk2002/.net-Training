using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Railway_Reservation_Mini_Project.Models
{

    public class Cancellation
    {
        public int CancellationId { get; set; }
        public int BookingId { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime CancellationDate { get; set; }
        public bool TicketCancelled { get; set; }
    }

}
