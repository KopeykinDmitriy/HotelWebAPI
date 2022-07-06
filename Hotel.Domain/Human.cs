namespace Hotel.Domain
{
    public class Human
    {
        public Guid HumanId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}