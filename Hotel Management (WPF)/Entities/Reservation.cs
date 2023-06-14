using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management__WPF_
{
    public class Reservation
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int GusteNumber { get; set; }

        public string StreetAddress { get; set; }

        public string Apt_Suite { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string RoomType { get; set; }

        public string RoomFloor { get; set; }

        public string RoomNumber { get; set; }

        public float TotalBill { get; set; }

        public string PaymentType { get; set; }

        public string CardType { get; set; }

        public string CardNumber { get; set; }

        public string CardExp { get; set; }

        public string CardCVV { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime LeavingDate { get; set; }

        public bool CheckIn { get; set; }

        public int BreakFast { get; set; }

        public int Lunch { get; set; }

        public int Dinner { get; set; }

        public bool Cleaning { get; set; }

        public bool Towel { get; set; }

        public bool SweetestSurprise { get; set; }

        public bool supplyStatus { get; set; }

        public int FoodBill { get; set; }


    }
}
