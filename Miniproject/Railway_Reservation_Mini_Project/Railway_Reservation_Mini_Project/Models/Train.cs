using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Railway_Reservation_Mini_Project.Models
{

    public class Train
    {
        public int TrainId { get; set; }
        public string TrainNo { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string RunningDays { get; set; }
        public bool IsDeleted { get; set; }
    }


}
