namespace Vehicle.WebAPI.Models
{
    public class SeatsGetModel
    {
        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public int SeatTypeColourId { get; set; }
        public SeatTypeColourGetModel SeatTypeColour { get; set; }
    }
}
