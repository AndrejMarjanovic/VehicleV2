namespace Vehicle.WebAPI.Models
{
    public class SeatTypeColourGetModel
    {
        public int Id { get; set; }
        public int SeatTypeId { get; set; }
        public SeatTypeGetModel SeatType { get; set; }
        public int ColourId { get; set; }
        public ColourGetModel Colour { get; set; }
    }
}
