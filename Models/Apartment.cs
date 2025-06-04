public class Apartment
{
    public int Id { get; set; }
    public string Address { get; set; }
    public decimal PricePerNight { get; set; }
    public int OwnerId { get; set; }
    public User Owner { get; set; }
}