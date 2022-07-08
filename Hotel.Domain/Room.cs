namespace Hotel.Domain
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomFloor { get; set; }
        public int RoomPlaces { get; set; }
        public int RoomPriceDefault { get; set; }
    }
}